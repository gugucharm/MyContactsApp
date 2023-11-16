using AutoMapper;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Models;
namespace MyContactsApp.DAL.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ContactDTO, Contact>()
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore());
            CreateMap<UserDTO, User>();
        }
    }
}
