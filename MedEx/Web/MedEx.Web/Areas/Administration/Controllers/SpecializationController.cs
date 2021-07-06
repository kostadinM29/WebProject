﻿using System.Security.Claims;
using System.Threading.Tasks;
using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Services.Data.Specializations;
using MedEx.Web.ViewModels.Administration.SpecializationViewModels;
using MedEx.Web.ViewModels.PatientViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Areas.Administration.Controllers
{
    public class SpecializationController : AdministrationController
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(SpecializationCreateInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }


            await _specializationService.CreateAsync(input);

            // TODO Redirect to your profile
            return Redirect("/");
        }
    }
}
