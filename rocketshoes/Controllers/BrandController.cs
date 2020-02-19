using Microsoft.AspNetCore.Http;
using rocketshoes.DAO;
using rocketshoes.Models;
using System.IO;

namespace rocketshoes.Controllers
{
    public class BrandController : PadraoController<BrandsViewModel>
    {

        public BrandController()
        {
            DAO = new BrandsDAO();
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

        protected override void ValidaDados(BrandsViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Name))
                ModelState.AddModelError("Name", "Preencha o nome.");

            //Imagem será obrigatio apenas na inclusão. 
            //Na alteração iremos considerar a que já estava salva.
            if (model.Image == null && operacao == "I")
                ModelState.AddModelError("Imagem", "Escolha uma imagem.");

            if (model.Image != null && model.Image.Length / 1024 / 1024 >= 2)
                ModelState.AddModelError("Imagem", "Imagem limitada a 2 mb.");

            if (ModelState.IsValid)
            {
                //na alteração, se não foi informada a imagem, iremos manter a que
                //já estava salva.
                if (operacao == "A" && model.Image == null)
                {
                    BrandsViewModel brand = DAO.Consulta(model.Id);
                    model.ByteImage = brand.ByteImage;
                }
                else
                {
                    model.ByteImage = ConvertImageToByte(model.Image);
                }
            }
        }
    }
}