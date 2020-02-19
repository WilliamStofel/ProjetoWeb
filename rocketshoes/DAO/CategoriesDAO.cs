using rocketshoes.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace rocketshoes.DAO
{
    public class CategoriesDAO : PadraoDAO<CategoriesViewModel>
    {
        protected override SqlParameter[] CriaParametros(CategoriesViewModel model)
        {
            SqlParameter[] parametros = {
                new SqlParameter("id", model.Id),
                new SqlParameter("name", model.Name),
                new SqlParameter("description", model.Description)
            };

            return parametros;
        }

        protected override CategoriesViewModel MontaModel(DataRow registro)
        {
            CategoriesViewModel category = new CategoriesViewModel();
            category.Id = Convert.ToInt32(registro["id"]);
            category.Name = registro["name"].ToString();
            category.Description = registro["description"].ToString();

            return category;
        }

        protected override void SetTabela()
        {
            Tabela = "Categories";
        }
    }
}
