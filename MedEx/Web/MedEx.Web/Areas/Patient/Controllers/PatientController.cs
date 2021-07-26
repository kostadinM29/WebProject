using MedEx.Common;
using MedEx.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Areas.Patient.Controllers
{
    [Authorize(Roles = GlobalConstants.PatientRoleName)]
    [Area("Patient")]
    public class PatientController : BaseController
    {
    }
}
