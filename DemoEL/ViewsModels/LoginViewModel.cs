using System.ComponentModel.DataAnnotations;

namespace DemoEL.ViewsModels
{

	
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress(ErrorMessage = "Invalide Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password Is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool IAgree { get; set; }
	}
}
