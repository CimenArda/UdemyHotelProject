using AutoMapper;
using HotelProject.DtoLater.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig :Profile
    {
        public AutoMapperConfig()
        {
                CreateMap<RoomAddDto,Room>().ReverseMap();
                CreateMap<RoomUpdateDto,Room>().ReverseMap();
                
        }


    }
}
