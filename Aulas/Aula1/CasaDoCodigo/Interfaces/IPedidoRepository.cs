using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void AddItem(string codigo);
        UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido);
        Pedido UpDateCadastro(Cadastro cadastro);
    }
}