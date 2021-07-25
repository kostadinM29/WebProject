using MedEx.Common;
using MedEx.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Areas.PatientRole.Controllers
{
    [Authorize(Roles = GlobalConstants.PatientRoleName)]
    [Area("PatientRole")]
    public class PatientRoleController : BaseController
    {
    }
}
