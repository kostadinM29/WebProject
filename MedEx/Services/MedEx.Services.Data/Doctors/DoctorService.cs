using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Services.Mapping;
using MedEx.Web.ViewModels.DoctorViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Doctors
{
    public class DoctorService : IDoctorService
    {
        private readonly IDeletableEntityRepository<Doctor> _doctorRepository;

        public DoctorService(IDeletableEntityRepository<Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        /*
         * getdoctorId
         *
         * getalldoctors
         *
         * savedoctor
         *
         * updatedoctor
         *
         *
         * getspecializations
         *
         * gettown
         * getaddress
         *
         * savetown
         * updatetown
         *
         * saveaddress
         * updateaddress
         *
         *
         * searchdoctors -- possible multiple methods depending on parameters
         *
         * searchsimilardoctors?
         *
         */

        public async Task CreateAsync(DoctorApplyInputModel model, string imagePath)
        {
            var doctor = new Doctor()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                Experience = model.Experience,
                Email = model.Email,
                Address = model.Address,
                Biography = model.Biography,
                TownId = model.TownId,
                SpecializationId = model.SpecializationId,
                UserId = model.UserId,
                HasApplied = true
            };
            Directory.CreateDirectory($"{imagePath}/doctors/");

            var extension = Path.GetExtension(model.Image.FileName).TrimStart('.');

            var dbImage = new Image
            {
                Extension = extension,
            };
            doctor.Images.Add(dbImage);

            var physicalPath = $"{imagePath}/doctors/{dbImage.Id}.{extension}";

            await using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await model.Image.CopyToAsync(fileStream);


            await _doctorRepository.AddAsync(doctor);
            await _doctorRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllValidatedDoctors<T>(int page, int itemsPerPage = 12)
        {
            var model = _doctorRepository.AllAsNoTracking()
                .Where(d => d.IsValidated)
                .OrderBy(d => d.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

            return model;
        }

        public IEnumerable<T> GetAllAppliedDoctors<T>(int page, int itemsPerPage = 12) // can possibly use this for the doctor pagination for patients
        {
            var model = _doctorRepository.AllAsNoTracking()
                .Where(d => d.IsValidated == false)
                .OrderBy(d => d.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

            return model;
        }

        public int GetAppliedAndNotValidatedDoctorsCount() => _doctorRepository.AllAsNoTracking().Count(d => d.HasApplied && d.IsValidated == false);

        public Doctor GetDoctorById(int doctorId) => _doctorRepository.All().FirstOrDefault(d => d.Id == doctorId);

        public async Task<bool> VerifyAsync(int doctorId)
        {
            var doctor = GetDoctorById(doctorId);
            if (doctor == null)
            {
                return false;
            }

            doctor.IsValidated = true;

            await _doctorRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int doctorId) // potential spaghetti code
        {
            var doctor = GetDoctorById(doctorId);

            if (doctor == null)
            {
                return false;
            }

            _doctorRepository.Delete(doctor);
            await _doctorRepository.SaveChangesAsync();
            return true;
        }
    }
}
