using DemoDAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace DemoEL.ViewsModels
{
    public class DepurtmentViewModelcs
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Code is Required")]
        public string Code { get; set; }
        public DateTime DataOfCarantion { get; set; }


        [InverseProperty("Depurtment")]
        public IEnumerable<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
