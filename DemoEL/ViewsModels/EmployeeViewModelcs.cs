using DemoDAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace DemoEL.ViewsModels
{
    public class EmployeeViewModelcs
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Name is Required")]
        //[MaxLength(50, ErrorMessage = "Max Length is 50 char")]
        //[MinLength(5, ErrorMessage = "Min Length is 5 char")]

        public string ImageName { get; set; }

        public IFormFile Image { get; set; }
        public string Name { get; set; }
        //[Range(22, 40, ErrorMessage = "Age Most be From 22 to 40")]
        public int Age { get; set; }
        //[Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        //[DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActve { get; set; }

        //[EmailAddress]
        public string Email { get; set; }
        //[Phone]
        public string PhoneNumber { get; set; }
        public DateTime HireData { get; set; }
        [ForeignKey("Depurtment")]
        public int? DepurtmentId { get; set; }
        [InverseProperty("Employees")]
        public Depurtment Depurtment { get; set; }
    }
}
