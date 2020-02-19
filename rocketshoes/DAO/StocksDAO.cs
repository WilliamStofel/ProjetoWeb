using rocketshoes.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace rocketshoes.DAO
{
    public class StocksDAO : PadraoDAO<StocksViewModel>
    {
        protected override SqlParameter[] CriaParametros(StocksViewModel model)
        {
            SqlParameter[] parametros = {
                new SqlParameter("id", model.Id),
                new SqlParameter("product_id", model.ProductId),
                new SqlParameter("amount", model.Amount)
            };

            return parametros;
        }

        protected override StocksViewModel MontaModel(DataRow registro)
        {
            StocksViewModel stock = new StocksViewModel();

            stock.Id = Convert.ToInt32(registro["id"]);
            stock.ProductId = Convert.ToInt32(registro["product_id"]);
            stock.Amount = Convert.ToInt32(registro["amount"]);

            return stock;
        }

        protected override void SetTabela()
        {
            Tabela = "Stocks";
        }
    }
}
