using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDAL.Models
{
    public class Employee
    {

        public int Id { get; set; }
        [Required]
        [MaxLength]
        public string ImageName { get; set; }
        public string Name { get; set; }
 
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
    
        public decimal Salary { get; set; }

        public bool IsActve { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public DateTime HireData { get; set; }
        public DateTime CritionData { get; set; }= DateTime.Now;
        [ForeignKey("Depurtment")]
        public int? DepurtmentId { get; set; }
        [InverseProperty("Employees")]
        public Depurtment Depurtment { get; set; }

    }
}
