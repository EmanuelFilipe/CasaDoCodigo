using System.Collections.Generic;
using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);
        IList<Produto> GetProdutos();
    }
}