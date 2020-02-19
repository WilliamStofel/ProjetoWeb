using System.Data.SqlClient;

namespace rocketshoes.DAO
{
    public static class ConexaoBD
    {
        public static SqlConnection GetConexao()
        {
            //string strCon = "Data Source=LOCALHOST;Initial Catalog=rocketshoes;user id=sa; password=123456";
            string strCon = "Data Source=LOCALHOST;Initial Catalog=rocketshoes;Integrated Security=SSPI;";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
