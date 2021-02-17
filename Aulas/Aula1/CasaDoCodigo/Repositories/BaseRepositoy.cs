using CasaDoCodigo.Context;
using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class BaseRepositoy<T> where T : BaseModel
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<T> dbSet;

        public BaseRepositoy(ApplicationContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
    }
}
