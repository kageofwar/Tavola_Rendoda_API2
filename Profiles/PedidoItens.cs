using AutoMapper;
using Tavola_api_2.Data.Dtos;
using Tavola_api_2.Dtos;
using Tavola_api_2.Models;

namespace Tavola_api_2.Profiles
 {
    public class PedidoItensProfile : Profile
    {
        public PedidoItensProfile()
        {
            CreateMap<PedidoItens, ReadPedidoItensDto>();
        }
    }
 }