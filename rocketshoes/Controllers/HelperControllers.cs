using Microsoft.AspNetCore.Http;
using System;

namespace rocketshoes.Controllers
{
    public class HelperControllers
    {
        public static Boolean VerifyLoggedUser(ISession session)
        {
            string logged = session.GetString("Logged");
            if (logged == null)
                return false;
            else
                return true;
        }
    }
}
