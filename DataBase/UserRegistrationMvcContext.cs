using CadastroDeUsuario.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeUsuario.DataBase
{
    public class UserRegistrationMvcContext : DbContext
    {
        public UserRegistrationMvcContext(DbContextOptions<UserRegistrationMvcContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}