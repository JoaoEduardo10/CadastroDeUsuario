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

        public async Task<User?> FindByEmailAsync(User obj)
        {
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(user => user.Email == obj.Email);

                return user;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

        }


        public async Task<User> FindByIdAsync(int id)
        {
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(user => user.Id == id) ?? throw new Exception("Usuário não existe");


                return user;
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
        }

        public async Task InsertAsync(User obj)
        {
            var user = await FindByEmailAsync(obj);

            if (user != null)
            {
                throw new Exception("Usuário já existe");
            }

#pragma warning disable CS8634 
            _context.Add(user);
#pragma warning restore CS8634 
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var user = await FindByIdAsync(id);

            _context.User.Remove(user);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, User obj)
        {
            try
            {
                User user = await FindByIdAsync(id);

                user.Name = obj.Name;
                user.Email = obj.Email;

                await _context.SaveChangesAsync();
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
        }
    }
}