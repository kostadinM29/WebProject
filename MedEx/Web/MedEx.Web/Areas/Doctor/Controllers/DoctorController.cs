using MedEx.Common;
using MedEx.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Areas.Doctor.Controllers
{
    [Authorize(Roles = GlobalConstants.DoctorRoleName)]
    [Area("Doctor")]
    public class DoctorController : BaseController
    {
    }
}
