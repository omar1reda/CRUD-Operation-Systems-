using DemoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL.Interfaces
{
    public interface IGenericInterface <T> 
    {
       Task< IEnumerable<T>> GetAllAsync();

        Task AddAsync(T item);

        void Delete(T item);

        void Update(T item);

        Task<T> GetByIdAsync(int id);
    }
}
