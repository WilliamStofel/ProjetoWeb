using Microsoft.AspNetCore.Http;
using System;

namespace rocketshoes.Models
{
    public class BrandsViewModel : PadraoViewModel
    {
        public string Name { get; set; }

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
