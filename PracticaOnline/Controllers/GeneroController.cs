using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetIdentity.Controllers
{
    public class GeneroController : Controller
    {
        [Authorize(Policy = "SoloMasculino")]
        public IActionResult MasculinoOnly()
        {
            return View();
        }

        [Authorize(Policy = "SoloFemenino")]
        public IActionResult FemeninoOnly()
        {
            return View();
        }

        [Authorize(Policy = "SoloOtro")]
        public IActionResult OtroOnly()
        {
            return View();
        }
    }
}
