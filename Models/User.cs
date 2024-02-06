using System.ComponentModel.DataAnnotations;

namespace CadastroDeUsuario.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} do Usuário é obrigatório!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O Minimo de letras para o {0} é {1} e o maximo é {2}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} do Usuário é obrigatório!")]
        [EmailAddress(ErrorMessage = "O formato do {0} é  invalido!")]
        public string Email { get; set; }


        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}