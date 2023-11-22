using System.ComponentModel.DataAnnotations;

namespace DemoEL.ViewsModels
{
	public class ForgetPasswordViewModel
	{
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress(ErrorMessage = "Invalide Email")]
		public string Email { get; set; }
	}
}
