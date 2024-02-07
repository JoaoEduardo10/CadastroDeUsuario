namespace CadastroDeUsuario.Models.ViewModel
{
    public class UserFormViewModel
    {
        public User User { get; set; }


#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public UserFormViewModel()
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        {

        }


        public UserFormViewModel(User user)
        {
            User = user;
        }
    }
}