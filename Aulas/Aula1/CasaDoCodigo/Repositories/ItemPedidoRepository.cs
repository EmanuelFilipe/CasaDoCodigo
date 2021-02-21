using CasaDoCodigo.Context;
using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ItemPedidoRepository : BaseRepositoy<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext context) : base(context)
        {
        }

        public ItemPedido GetItemPedido(int itemPedidoId)
        {
            return dbSet.Where(i => i.Id == itemPedidoId).SingleOrDefault();
        }

        public void RemoveItemPedido(int itemPedidoId)
        {
            var itemPedido = GetItemPedido(itemPedidoId);
            dbSet.Remove(itemPedido);
        }
    }
}
