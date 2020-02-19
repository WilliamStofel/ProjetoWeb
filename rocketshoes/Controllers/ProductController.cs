using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using rocketshoes.DAO;
using rocketshoes.Models;
using System.Collections.Generic;
using System.IO;

namespace rocketshoes.Controllers
{
    public class ProductController : PadraoController<ProductsViewModel>
    {

        public ProductController()
        {
            DAO = new ProductsDAO();
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

        protected override void ValidaDados(ProductsViewModel model, string operacao)
        {
            
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Name))
                ModelState.AddModelError("Name", "Preencha o nome.");
            if (model.Price <= 0 )
                ModelState.AddModelError("Price", "Preencha o preço.");
            if ( model.Gender == "0")
                ModelState.AddModelError("Gender", "Preencha o gênero.");
            if (model.BrandId == 0)
                ModelState.AddModelError("BrandId", "Preencha a marca.");
            if (model.CategoryId == 0)
                ModelState.AddModelError("CategoryId", "Preencha a categoria.");
            if (string.IsNullOrEmpty(model.Color))
                ModelState.AddModelError("Color", "Preencha a cor.");
            if (model.Size <= 0)
                ModelState.AddModelError("Size", "Preencha o tamanho.");
            

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
                    ProductsViewModel product = DAO.Consulta(model.Id);
                    model.ByteImage = product.ByteImage;
                }
                else
                {
                    model.ByteImage = ConvertImageToByte(model.Image);
                }
            }
        }

        protected override void PreencheDadosParaView(string Operacao, ProductsViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            ListGenders();
            ListBrands();
            ListCategories();
        }

        private void ListGenders()
        {
            List<string> genders = new List<string>
            {
                "Masculino",
                "Feminino"
            };
            List<SelectListItem> gendersList = new List<SelectListItem>();

            gendersList.Add(new SelectListItem("Selecione um gênero", "0"));

            foreach (var gender in genders)
            {
                SelectListItem item = new SelectListItem(gender.ToString(), (genders.IndexOf(gender) + 1).ToString());
                gendersList.Add(item);
            }
            ViewBag.Genders = gendersList;
        }

        private void ListBrands()
        {
            BrandsDAO brandsDAO = new BrandsDAO();
            var brands = brandsDAO.Listagem();
            List<SelectListItem> brandsList = new List<SelectListItem>();

            brandsList.Add(new SelectListItem("Selecione uma marca", "0"));

            foreach (var brand in brands)
            {
                SelectListItem item = new SelectListItem(brand.Name, brand.Id.ToString());
                brandsList.Add(item);
            }
            ViewBag.Brands = brandsList;
        }

        private void ListCategories()
        {
            CategoriesDAO categoriesDAO = new CategoriesDAO();
            var categories = categoriesDAO.Listagem();
            List<SelectListItem> categoriesList = new List<SelectListItem>();

            categoriesList.Add(new SelectListItem("Selecione uma marca", "0"));

            foreach (var category in categories)
            {
                SelectListItem item = new SelectListItem(category.Name, category.Id.ToString());
                categoriesList.Add(item);
            }
            ViewBag.Categories = categoriesList;
        }
    }
}