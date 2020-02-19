using rocketshoes.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace rocketshoes.DAO
{
    public class UserDAO : PadraoDAO<UserViewModel>
    {
        protected override SqlParameter[] CriaParametros(UserViewModel model)
        {
            SqlParameter[] parametros = {
                new SqlParameter("id", model.Id),
                new SqlParameter("name", model.Name),
                new SqlParameter("email", model.Email),
                new SqlParameter("password", model.Password),
                new SqlParameter("seller", model.Seller)
            };

            return parametros;
        }

        protected override UserViewModel MontaModel(DataRow registro)
        {
            UserViewModel user = new UserViewModel();

            user.Id = Convert.ToInt32(registro["id"]);
            user.Name = registro["name"].ToString();
            user.Email = registro["email"].ToString();
            user.Password = registro["password"].ToString();
            user.Seller = Convert.ToInt32(registro["seller"]);

            return user;
        }

        protected override void SetTabela()
        {
            Tabela = "Users";
        }
                
    }
}
