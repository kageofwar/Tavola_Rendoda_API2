using AutoMapper;
using Tavola_api_2.Dtos;
using Tavola_api_2.Models;

namespace Tavola_api_2.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, ReadPedidoDto>();
        }
    }
}