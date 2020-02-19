using rocketshoes.DAO;
using rocketshoes.Models;

namespace rocketshoes.Controllers
{
    public class UserController : PadraoController<UserViewModel>
    {
        public UserController()
        {
            DAO = new UserDAO();
            GeraProximoId = true;
        }

        protected override void PreencheDadosParaView(string Operacao, UserViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
        }

        protected override void ValidaDados(UserViewModel User, string operacao)
        {
            base.ValidaDados(User, operacao);
            if (string.IsNullOrEmpty(User.Name))
                ModelState.AddModelError("Name", "Preencha o nome.");
            if (string.IsNullOrEmpty(User.Email))
                ModelState.AddModelError("Email", "Preencha o email.");
            if (string.IsNullOrEmpty(User.Password))
                ModelState.AddModelError("Password", "Preencha a senha.");
            
        }

        public bool validauser(string usuario, string password)
        {

            UserViewModel user = new UserViewModel();
            
            if (DAO.ValidaLogin(user, usuario, password) == true)
                return true;
            else
                return false; 
              

        }
    }
}