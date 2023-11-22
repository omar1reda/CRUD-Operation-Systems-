using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRopositore EmployeeRopositore { get; set; }
        public IDepurtmentRepositore DepurtmentRepositore { get; set; }

        Task<int> Complete();


    }
}
