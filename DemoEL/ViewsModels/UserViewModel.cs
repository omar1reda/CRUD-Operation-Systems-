using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoEL.ViewsModels
{
	public class UserViewModel
	{
        public string Id { get; set; }

        [Required(ErrorMessage = "FName Is Required")]
		public string FName { get; set; }
		[Required(ErrorMessage = "LName Is Required")]
		public string LName { get; set; }
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress(ErrorMessage = "Invalide Email")]
		public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }



    }
}
