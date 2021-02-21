using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories.Interfaces
{
    public interface ICadastroRepository
    {
        Cadastro Update(int cadastroId, Cadastro novoCadastro);
    }
}