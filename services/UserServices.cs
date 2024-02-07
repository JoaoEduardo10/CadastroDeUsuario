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


        public async Task<List<User>> FindAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task InsertAsync(User obj)
        {
            _context.Add(obj);

            await _context.SaveChangesAsync();
        }

    }
}