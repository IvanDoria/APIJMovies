using APIJMovies.API.DAL.Models.Dtos;
using AutoMapper;
using PRACTICA.API.DAL.Models;

namespace APIJMovies.API.MoviesMapper
{
    public class Mappers : Profile
    {

        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
        }

    }
}
