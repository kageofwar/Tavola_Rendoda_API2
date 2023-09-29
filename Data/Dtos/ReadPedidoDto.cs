namespace Tavola_api_2.Dtos
{
    public class ReadPedidoDto
    {
        public int Id { get; set; }
        public string Forma_Pagamento { get; set; }
        public string Status_Pedido { get; set; }
        public int Total { get; set; }
    }
}