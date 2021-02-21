using CasaDoCodigo.Context;
using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CadastroRepository : BaseRepositoy<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext context) : base(context)
        {
        }

        public Cadastro Update(int cadastroId, Cadastro novoCadastro)
        {
            var cadastroDB = dbSet.Where(c => c.Id == cadastroId).SingleOrDefault();

            if (cadastroDB == null)
                throw new ArgumentNullException("Cadastro");

            cadastroDB.Update(novoCadastro);
            _context.SaveChanges();

            return cadastroDB;
        }
    }
}
