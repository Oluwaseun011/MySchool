using Microsoft.AspNetCore.Mvc;
using MySchool.Core.Application.Dtos;
using MySchool.Core.Application.Interfaces.Services;

namespace MySchool.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        { 
            _userService = userService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            var response = _userService.Login(request);
            if(!response.Status)
            {
                return View();
            }
            if (response.Data.Roles.Select(a => a.Name).Contains("SuperAdmin"))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
