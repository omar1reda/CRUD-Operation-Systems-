using DemoBLL.Interfaces;
using DemoDAL.Context;
using DemoDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL.Repositores
{
    public class GenericRepositore<T> : IGenericInterface<T> where T : class
    {
        private AppDbContext _Context;
        public GenericRepositore(AppDbContext Context)
        {
            _Context = Context;
        }
        public async Task AddAsync(T item)
        {
          
           await _Context.AddAsync(item);
         
        }

        public void Delete(T item)
        {
            _Context.Remove(item);
         
        }

        public async Task< IEnumerable<T> > GetAllAsync()
        {
            if (typeof(T) == typeof(Employee))
            {
                return  (IEnumerable<T>) await _Context.Employees.Include(e => e.Depurtment).ToListAsync();
            }
            return await _Context.Set<T>().ToListAsync();
        }

        public  async Task<T> GetByIdAsync(int id)
        {
            return await _Context.Set<T>().FindAsync(id);
        }

        public void Update(T item)
        {
            _Context.Update(item);
         
        }
    }
}
