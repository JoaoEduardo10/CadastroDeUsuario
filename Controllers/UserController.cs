using CadastroDeUsuario.Models;
using CadastroDeUsuario.Models.ViewModel;
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
            List<User> users = await _userServices.FindAllAsync();
            return View(users);
        }

        public IActionResult Create()
        {
            var viewModel = new UserFormViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(User user)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new UserFormViewModel { User = user };

                return View(viewModel);
            }

            await _userServices.InsertAsync(user);

            return RedirectToAction(nameof(Index));
        }
    }
}