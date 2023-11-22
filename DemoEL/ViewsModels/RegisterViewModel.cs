using System.ComponentModel.DataAnnotations;

namespace DemoEL.ViewsModels
{
	public class RegisterViewModel
	{

		[Required(ErrorMessage = "FName Is Required")]
        public string FName { get; set; }
		[Required(ErrorMessage = "LName Is Required")]
		public string LName { get; set; }
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress(ErrorMessage = "Invalide Email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password Is Required")]
		[DataType(DataType.Password)]

		public string Password { get; set; }
		[Required(ErrorMessage = "Confirm Password Is Required")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Password Dont Math")]
		public string ConfirmPassword { get; set; }

		public bool IAgree { get; set;}
	}
}
