using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {

        [Required(ErrorMessage ="İkon Linki giriniz.")]
        public string Icon { get; set; }
       
        [Required(ErrorMessage = "Başlık  giriniz.")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Açıklama giriniz.")]
        public string Description { get; set; }
    }
}
