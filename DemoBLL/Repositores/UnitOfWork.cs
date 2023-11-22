using DemoBLL.Interfaces;
using DemoDAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL.Repositores
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        public IEmployeeRopositore EmployeeRopositore { get ; set ; }
        public IDepurtmentRepositore DepurtmentRepositore { get; set; }
        public AppDbContext _dbContext { get; }

        public UnitOfWork(AppDbContext dbContext)
        {
            EmployeeRopositore = new EmployeeRopositore(dbContext);
            DepurtmentRepositore = new DepurtmentReposatore(dbContext);
            _dbContext = dbContext;
        }

        public async Task< int> Complete()
        {
            return  _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
