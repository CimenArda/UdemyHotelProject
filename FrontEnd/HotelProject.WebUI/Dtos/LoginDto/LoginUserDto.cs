using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Kullanıcı Adı giriniz.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı giriniz.")]
        public string Password { get; set; }
    }
}
