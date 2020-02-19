namespace rocketshoes.Models
{
    public class UserViewModel : PadraoViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Seller { get; set; }
    }
}
