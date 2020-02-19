using Microsoft.AspNetCore.Http;
using System;

namespace rocketshoes.Models
{
    public class ProductsViewModel : PadraoViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        public IFormFile Image { get; set; }
        public byte[] ByteImage { get; set; }
        public string Base64Image
        {
            get
            {
                if (ByteImage != null)
                    return Convert.ToBase64String(ByteImage);
                else
                    return string.Empty;
            }
        }
    }
}