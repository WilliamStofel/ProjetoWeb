using rocketshoes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace rocketshoes.DAO
{
    public abstract class PadraoDAO<T> where T : PadraoViewModel
    {
        protected PadraoDAO()
        {
            SetTabela();
        }

        protected string Tabela { get; set; }
        protected string Chave { get; set; } = "id";  // valor default
        protected abstract SqlParameter[] CriaParametros(T model);
        protected abstract T MontaModel(DataRow registro);

        protected abstract void SetTabela();

        public virtual void Insert(T model)
        {
            HelperDAO.ExecutaProc("spInsert_" + Tabela, CriaParametros(model));
        }

        public virtual void Update(T model)
        {
            HelperDAO.ExecutaProc("spUpdate_" + Tabela, CriaParametros(model));
        }


        public virtual void Delete(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("tabela", Tabela)
            };
            HelperDAO.ExecutaProc("spDelete", p);
        }

        public virtual T Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("tabela", Tabela)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultaUnico", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }



        public virtual int ProximoId()
        {   
            var p = new SqlParameter[]
              {
                new SqlParameter("tabela", Tabela)
              };
            var tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);
            return Convert.ToInt32(tabela.Rows[0][0]);
        }


        public virtual List<T> Listagem()
        {
            var parameters = new SqlParameter[]
             {
                new SqlParameter("tabela", Tabela),
             };

            var tabela = HelperDAO.ExecutaProcSelect("spConsulta", parameters);
            List<T> lista = new List<T>();

            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }

            return lista;
        }

        public virtual bool ValidaLogin(UserViewModel model, string usuario, string senha)
        {
            var p = new SqlParameter[]
              {
                  new SqlParameter("name", model.Name=usuario),
                  new SqlParameter("password", model.Password=senha)
                      
                      
              };
            var tabela = HelperDAO.ExecutaProcSelect("splogin", p);
            if (tabela.Rows.Count != 0 )
                return true;
            else
                return false;

        }

    }
}
