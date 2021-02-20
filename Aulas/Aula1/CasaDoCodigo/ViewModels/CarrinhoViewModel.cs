using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.ViewModels
{
    public class CarrinhoViewModel
    {
        public IList<ItemPedido> Itens { get; }

        public CarrinhoViewModel(IList<ItemPedido> itens)
        {
            Itens = itens;
        }

        // um método que irá retornar o valor total dos itens
        public decimal Total => Itens.Sum(i => i.PrecoUnitario * i.Quantidade);

    }
}
