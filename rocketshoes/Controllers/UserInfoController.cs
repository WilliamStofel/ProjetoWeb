using Microsoft.AspNetCore.Http;
using rocketshoes.DAO;
using rocketshoes.Models;
using System.IO;

namespace rocketshoes.Controllers
{
    public class UserInfoController : PadraoController<UserInfoViewModel>
    {
        public UserInfoController()
        {
            DAO = new UserInfoDAO();
            GeraProximoId = true;
        }

        public byte[] ConvertImageToByte(IFormFile file)
        {
            if (file != null)
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }
            else
                return null;
        }
        //protected override void PreencheDadosParaView(string Operacao, UserInfoViewModel model)
        //{
        //    base.PreencheDadosParaView(Operacao, model);
        //    PreparaListaCidadesParaCombo();
        //}

        //private void PreparaListaCidadesParaCombo()
        //{
        //    CidadeDAO cidadeDao = new CidadeDAO();
        //    var cidades = cidadeDao.Listagem();
        //    List<SelectListItem> listaCidades = new List<SelectListItem>();

        //    listaCidades.Add(new SelectListItem("Selecione uma cidade...", "0"));

        //    foreach (var cidade in cidades)
        //    {
        //        SelectListItem item = new SelectListItem(cidade.Nome, cidade.Id.ToString());
        //        listaCidades.Add(item);
        //    }
        //    ViewBag.Cidades = listaCidades;
        //}

        protected override void ValidaDados(UserInfoViewModel userInfo, string operacao)
        {
           base.ValidaDados(userInfo, operacao);


            if (string.IsNullOrEmpty(userInfo.Address))
                ModelState.AddModelError("Address", "Preencha o endereço.");
            if (string.IsNullOrEmpty(userInfo.City))
                ModelState.AddModelError("City", "Preencha a cidade.");
            if (userInfo.ZipCode == null || userInfo.ZipCode.Length < 9)
                ModelState.AddModelError("ZipCode", "Informe o CEP.");
            if (string.IsNullOrEmpty(userInfo.CardName))
                ModelState.AddModelError("CardName", "Insira o nome do cartão!");
            if (userInfo.CardNumber == null || userInfo.CardNumber.Length < 13)
                ModelState.AddModelError("CardNumber", "Quantidade de Digitos Inválido !");
            if (userInfo.SecurityNumber < 100)
                ModelState.AddModelError("SecurityNumber", "Código de segurança Inválido !");
        }
    }
}