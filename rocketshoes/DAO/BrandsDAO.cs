using rocketshoes.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace rocketshoes.DAO
{
    public class BrandsDAO : PadraoDAO<BrandsViewModel>
    {
        protected override SqlParameter[] CriaParametros(BrandsViewModel model)
        {
            object byteImage = model.ByteImage;
            if (byteImage == null)
                byteImage = DBNull.Value;

            SqlParameter[] parametros = {
                new SqlParameter("id", model.Id),
                new SqlParameter("name", model.Name),
                new SqlParameter("image", byteImage)
            };

            return parametros;
        }

        protected override BrandsViewModel MontaModel(DataRow registro)
        {
            BrandsViewModel brand = new BrandsViewModel();

            brand.Id = Convert.ToInt32(registro["id"]);
            brand.Name = registro["name"].ToString();


            if (registro["image"] != DBNull.Value)
                brand.ByteImage = registro["image"] as byte[];

            return brand;
        }

        protected override void SetTabela()
        {
            Tabela = "Brands";
        }
    }
}
