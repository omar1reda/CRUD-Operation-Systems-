using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DemoDAL.Models
{
	public class ApplicationUser : IdentityUser
	{

		[Required]
		public string FName { get; set; }
		[Required]
		public string LName { get; set; }
	
		public bool IAgree { get; set; }
	}
}
