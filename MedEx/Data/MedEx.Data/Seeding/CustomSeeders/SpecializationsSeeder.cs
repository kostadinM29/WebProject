using MedEx.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Data.Seeding.CustomSeeders
{
    public class SpecializationsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Specializations.Any())
            {
                return;
            }

            var specializations = new[]
            {
                new Specialization
                {
                    Name = "Dentist",
                    Description =
                        "According to American Dental Association, a dentist is a doctor of oral health. Oral health includes teeth, tongue and gums. A dentist is known to diagnose and treat issues of these three areas."
                },
                new Specialization
                {
                    Name = "Psychiatrist",
                    Description =
                        "Mental health is a vast field which requires our uttermost attention. Therefore, to treat what goes inside a human brain is difficult, due to the uncertainty of it. A psychiatrist helps treat and diagnose issues of mental health."
                },
                new Specialization
                {
                    Name = "Cardiothoracic surgeon",
                    Description =
                        "Thorax means the chest. A cardiothoracic surgeon treats conditions of the heart, lungs, oesophagus and other organs in the chest."
                },
                new Specialization
                {
                    Name = "Oncologist",
                    Description =
                        "Oncology involves the study of all types of cancers. This involves the radiation, medical and surgical. Oncologists can specialise in one type of cancer as well as the field is vast."
                },
                new Specialization
                {
                    Name = "Paediatrician",
                    Description =
                        "Paediatricians are doctors who treat children. Since a child’s body functions in a different manner from ours, due to many factors like age and growing stages, their illness and health issues are different from an adult. A paediatrician helps in mental behaviour issues and physical health problems."
                },
                new Specialization
                {
                    Name = "ENT specialist",
                    Description =
                        "ENT stands for ear, nose and throat. A specialist who treats and diagnoses the issues and troubles of these three areas. Also known as an otolaryngologist, an ENT specialist is a physician to trained to treat the disorders of ENT."
                },
                new Specialization
                {
                    Name = "Cardiologist",
                    Description =
                        "A cardiologist is a doctor that deals with the cardiovascular system. This means he or she treats any abnormality in our blood vessels and heart. This can include heart disease or condition which requires diagnosis and treatment."
                }
            };

            // Need them in particular order
            foreach (var specialization in specializations)
            {
                await dbContext.AddAsync(specialization);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
