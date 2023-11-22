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
    public class DepurtmentReposatore : GenericRepositore<Depurtment>, IDepurtmentRepositore
    {
        private readonly AppDbContext _dbContext;

        public DepurtmentReposatore(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }



    }
}
