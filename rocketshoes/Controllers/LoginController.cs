using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace rocketshoes.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }


        public IActionResult FazLogin(string usuario, string senha)
        {
            //Este é apenas um exemplo, aqui você deve consultar na sua tabela de usuários
            //se existem esse usuário e senha
            UserController user = new UserController();
            

            if (user.validauser(usuario, senha) == true)
            {
                HttpContext.Session.SetString("Logged", "true");
                ViewBag.Logged = HelperControllers.VerifyLoggedUser(HttpContext.Session);
                return RedirectToAction("index", "Home");
            }
            else
            {
                
                
                ViewBag.Error = "Usuário ou senha inválidos!";
                return View("Index");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}