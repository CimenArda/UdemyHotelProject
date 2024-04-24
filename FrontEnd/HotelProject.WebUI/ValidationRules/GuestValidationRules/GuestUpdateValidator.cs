using FluentValidation;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class GuestUpdateValidator:AbstractValidator<UpdateGuestDto>
    {
        public GuestUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı boş geçilemez.");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyisim Alanı boş geçilemez.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir Alanı boş geçilemez.");

            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Minimum 2 karakterli veri girişi yapınız");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Minimum 3 karakterli veri girişi yapınız");
            RuleFor(x => x.SurName).MinimumLength(2).WithMessage("Minimum 2 karakterli veri girişi yapınız");


            RuleFor(x => x.Name).MaximumLength(15).WithMessage("Maksimum 15 karakterli veri girişi yapınız");
            RuleFor(x => x.City).MaximumLength(15).WithMessage("Maksimum 15 karakterli veri girişi yapınız");
            RuleFor(x => x.SurName).MaximumLength(15).WithMessage("Maksimum 15 karakterli veri girişi yapınız");

        }
    }
}
