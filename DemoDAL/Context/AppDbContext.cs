using DemoDAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDAL.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
	{
       
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

      

        public DbSet<Depurtment> Depurtments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
