using AutoMapper;
using Tavola_api_2.Data.Dtos;
using Tavola_api_2.Models;

namespace Tavola_api_2.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<Produto, ReadProdutoDto>();
    } 
}