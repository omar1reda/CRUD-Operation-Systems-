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
    public class EmployeeRopositore : GenericRepositore<Employee>, IEmployeeRopositore
    {
        private AppDbContext _dbContext;
        public EmployeeRopositore(AppDbContext context):base(context) 
        {
            _dbContext = context;
        }

        public  IEnumerable<Employee>  SearchByName(string name)
        {
            return  _dbContext.Employees.Where(E=>E.Name.ToLower().Contains(name));
        }

    }
}
