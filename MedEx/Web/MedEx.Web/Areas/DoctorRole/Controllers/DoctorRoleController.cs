using MedEx.Common;
using MedEx.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Areas.DoctorRole.Controllers
{
    [Authorize(Roles = GlobalConstants.DoctorRoleName)]
    [Area("DoctorRole")]
    public class DoctorRoleController : BaseController
    {
    }
}
