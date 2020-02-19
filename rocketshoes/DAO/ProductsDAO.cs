using rocketshoes.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace rocketshoes.DAO
{
    public class ProductsDAO : PadraoDAO<ProductsViewModel>
    {
        protected override SqlParameter[] CriaParametros(ProductsViewModel model)
        {
            object byteImage = model.ByteImage;
            if (byteImage == null)
                byteImage = DBNull.Value;

            SqlParameter[] parametros = {
                new SqlParameter("id", model.Id),
                new SqlParameter("name", model.Name),
                new SqlParameter("price", model.Price),
                new SqlParameter("gender", model.Gender),
                new SqlParameter("color", model.Color),
                new SqlParameter("size", model.Size),
                new SqlParameter("brand_id", model.BrandId),
                new SqlParameter("category_id", model.CategoryId),
                new SqlParameter("image", byteImage)
            };

            return parametros;
        }

        protected override ProductsViewModel MontaModel(DataRow registro)
        {
            ProductsViewModel product = new ProductsViewModel();

            product.Id = Convert.ToInt32(registro["id"]);
            product.Name = registro["name"].ToString();
            product.Price = Convert.ToDouble(registro["price"]);
            product.Gender = registro["gender"].ToString();
            product.Color = registro["color"].ToString();
            product.Size = Convert.ToInt32(registro["size"]);
            product.BrandId = Convert.ToInt32(registro["brand_id"]);
            product.CategoryId = Convert.ToInt32(registro["category_id"]);

            if (registro["image"] != DBNull.Value)
                product.ByteImage = registro["image"] as byte[];

            return product;
        }

        protected override void SetTabela()
        {
            Tabela = "Products";
        }
    }
}
