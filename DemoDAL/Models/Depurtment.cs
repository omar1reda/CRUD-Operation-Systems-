using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDAL.Models
{
    public class Depurtment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public DateTime DataOfCarantion { get; set; }


        [InverseProperty("Depurtment")]
        public IEnumerable<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
