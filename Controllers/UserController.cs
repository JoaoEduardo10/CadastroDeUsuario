using System.Diagnostics;
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "id não encontrado" });
            }

            try
            {
                var user = await _userServices.FindByIdAsync(id.Value);


                return View(user);
            }
            catch (Exception error)
            {

                return RedirectToAction(nameof(Error), new { message = error.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userServices.RemoveAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string message)
        {

            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}