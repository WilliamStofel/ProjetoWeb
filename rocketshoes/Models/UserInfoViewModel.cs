using Microsoft.AspNetCore.Http;
using System;

namespace rocketshoes.Models
{
    public class UserInfoViewModel : PadraoViewModel
    {
        public int IdUser { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public int SecurityNumber { get; set; }

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
