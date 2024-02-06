using CadastroDeUsuario.DataBase;
using CadastroDeUsuario.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeUsuario.services
{
    public class UserServices
    {
        private readonly UserRegistrationMvcContext _context;

        public UserServices(UserRegistrationMvcContext context)
        {
            _context = context;
        }


        public async Task<List<User>> FindAll()
        {
            return await _context.User.ToListAsync();
        }

        public async Task AddUser(User user)
        {
            _context.Add(user);

            await _context.SaveChangesAsync();
        }

    }
}