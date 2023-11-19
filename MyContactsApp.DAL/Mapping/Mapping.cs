using AutoMapper;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Models;
namespace MyContactsApp.DAL.Mapping
{
    // Declaring a mapping profile for our commands
    public class Mapping : Profile
    {
        // Declaring necessary mapping between models and their DTOs
        // with the use of hashing between UserDTO and User
        public Mapping()
        {
            CreateMap<ContactDTO, Contact>();

            CreateMap<UserDTO, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)))
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<SubcategoryDTO, Subcategory>();
        }
    }
}
