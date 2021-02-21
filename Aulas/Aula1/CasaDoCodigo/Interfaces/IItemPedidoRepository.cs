using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories.Interfaces
{
    public interface IItemPedidoRepository
    {
        ItemPedido GetItemPedido(int itemPedidoId);
        void RemoveItemPedido(int itemPedidoId);
    }
}