
using CadastroDeUsuario.Models;

namespace CadastroDeUsuario.DataBase
{
    public class SeedingServices
    {
        private readonly UserRegistrationMvcContext _context;

        public SeedingServices(UserRegistrationMvcContext context)
        {
            _context = context;
        }


        public void Seed()
        {

            if (_context.User.Any())
            {
                return;
            }

            User u1 = new User(1, "Eduardo", "eduardo@gmail.com.br");
            User u2 = new User(2, "Caio", "Caio@gmail.com.br");
            User u3 = new User(3, "Felipe", "Felipe@gmail.com.br");



            _context.User.AddRange(u1, u2, u3);

            _context.SaveChanges();
        }
    }
}