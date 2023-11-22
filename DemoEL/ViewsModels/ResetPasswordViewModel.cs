using System.ComponentModel.DataAnnotations;

namespace DemoEL.ViewsModels
{
	public class ResetPasswordViewModel
	{
		[Required(ErrorMessage = "NewPassword Is Required")]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }

		[Required(ErrorMessage = "Confirm NewPassword Is Required")]
		[DataType(DataType.Password)]
		[Compare("NewPassword", ErrorMessage = "NewPassword Dont Math")]
		public string ConfirmNewPassword { get; set; }


	}
}
