    using rocketshoes.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace rocketshoes.DAO
{
    public class UserInfoDAO : PadraoDAO<UserInfoViewModel>
    {
        protected override SqlParameter[] CriaParametros(UserInfoViewModel model)
        {
            object byteImage = model.ByteImage;
            if (byteImage == null)
                byteImage = DBNull.Value;

            SqlParameter[] parametros = {
                new SqlParameter("id", model.Id),
                new SqlParameter("id_user", model.IdUser),
                new SqlParameter("image", byteImage),
                new SqlParameter("address", model.Address),
                new SqlParameter("city", model.City),
                new SqlParameter("zip_code", model.ZipCode),
                new SqlParameter("card_number", model.CardNumber),
                new SqlParameter("card_name", model.CardName),
                new SqlParameter("security_number", model.SecurityNumber)
            };

            return parametros;
        }

        protected override UserInfoViewModel MontaModel(DataRow registro)
        {
            UserInfoViewModel userInfo = new UserInfoViewModel();

            userInfo.Id = Convert.ToInt32(registro["id"]);
            userInfo.IdUser = Convert.ToInt32(registro["id_user"]);
            userInfo.Address = registro["address"].ToString();
            userInfo.City = registro["city"].ToString();
            userInfo.ZipCode = registro["zip_code"].ToString();
            userInfo.CardNumber = registro["card_number"].ToString();
            userInfo.CardName = registro["card_name"].ToString();
            userInfo.SecurityNumber = Convert.ToInt32(registro["security_number"]);

            if (registro["image"] != DBNull.Value)
                userInfo.ByteImage = registro["image"] as byte[];

            return userInfo;
        }

        protected override void SetTabela()
        {
            Tabela = "User_Info";
        }
    }
}
