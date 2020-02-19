using Microsoft.AspNetCore.Http;
using rocketshoes.DAO;
using rocketshoes.Models;
using System.IO;

namespace rocketshoes.Controllers
{
    public class CategoryController : PadraoController<CategoriesViewModel>
    {

        public CategoryController()
        {
            DAO = new CategoriesDAO();
            GeraProximoId = true;
        }

        /// <summary>
        /// Converte a imagem recebida no form em um vetor de bytes
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
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

        protected override void ValidaDados(CategoriesViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Name))
                ModelState.AddModelError("Name", "Preencha o nome.");
            if (string.IsNullOrEmpty(model.Description))
                ModelState.AddModelError("Description", "Preencha a descrição.");

            if (ModelState.IsValid)
            {
                //na alteração, se não foi informada a imagem, iremos manter a que
                //já estava salva.
                if (operacao == "A")
                {
                    CategoriesViewModel category = DAO.Consulta(model.Id);
                }
            }
        }
    }
}