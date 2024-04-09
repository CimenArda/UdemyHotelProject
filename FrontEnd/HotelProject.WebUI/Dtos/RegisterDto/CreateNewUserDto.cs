using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad Alanı gereklidir.")]
        public string Name { get; set; }



        [Required(ErrorMessage = "Soyad Alanı gereklidir.")]
        public string Surname { get; set; }



        [Required(ErrorMessage = "Kullanıcı Adı Alanı gereklidir.")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Mail Alanı gereklidir.")]
        public string Mail { get; set; }


        [Required(ErrorMessage = "Şifre Alanı gereklidir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar Alanı gereklidir.")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmamaktadır")]
        public string PasswordConfirm { get; set; }


    }
}
