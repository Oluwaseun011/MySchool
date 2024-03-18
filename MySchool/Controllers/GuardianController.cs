using Microsoft.AspNetCore.Mvc;
using MySchool.Core.Application.Dtos;
using MySchool.Core.Application.Interfaces.Services;

namespace MySchool.Controllers
{
    public class GuardianController : Controller
    {
        private readonly IGuardianService _guardianService;
        public GuardianController(IGuardianService guardianService)
        {
            _guardianService = guardianService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(GuardianRequest model)
        {
            var response = _guardianService.Create(model);
            if(response == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(string id)
        {
            var response = _guardianService.Get(id);
            if(response == null)
            {
                return RedirectToAction("Guardians");
            }
            return View(response.Data);
        }

        public IActionResult Guardians()
        {
            var response = _guardianService.GetAll();
            return View(response.Data);
        }
    }
}
