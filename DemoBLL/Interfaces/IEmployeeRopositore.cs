using DemoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL.Interfaces
{
    public interface IEmployeeRopositore : IGenericInterface<Employee>
    {
        public IEnumerable<Employee> SearchByName(string name);

    }
}
