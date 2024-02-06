using CadastroDeUsuario.Models;
using CadastroDeUsuario.services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeUsuario.Controllers
{
    public class UserController : Controller
    {
        private readonly UserServices _userServices;

        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        public async Task<IActionResult> Index()
        {
            List<User> users = await _userServices.FindAll();
            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}