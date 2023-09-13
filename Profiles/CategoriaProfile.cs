using AutoMapper;
using Tavola_api_2.Data.Dtos;
using Tavola_api_2.Models;

namespace Tavola_api_2.Profiles
 {
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, ReadCategoriaDto>();
        }
    }
 }