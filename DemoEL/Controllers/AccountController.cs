using DemoDAL.Models;
using DemoEL.Helpers;

using DemoEL.ViewsModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;


namespace DemoEL.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<ApplicationUser> _UserManigar { get; }
		private SignInManager<ApplicationUser> _SignInManager { get; }

		public AccountController(UserManager<ApplicationUser> UserManigar , SignInManager<ApplicationUser> signInManager)
		{
			_UserManigar = UserManigar;
			_SignInManager = signInManager;
		}

		#region ////// Register ///////
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var User = new ApplicationUser()
				{
					UserName = model.Email.Split('@')[0],
					FName = model.FName,
					LName = model.LName,
					Email = model.Email,
					IAgree = model.IAgree
				};

				var Result = await _UserManigar.CreateAsync(User, model.Password);
				if (Result.Succeeded)
				{
					return RedirectToAction("login");
				}
				else
				{
					foreach (var error in Result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}

			}
			return View(model);
		}

		#endregion



		#region Login /////////
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{

			if (ModelState.IsValid)
			{
				var User = await _UserManigar.FindByEmailAsync(model.Email);
				if (User != null)
				{
					var UserLogin = await _UserManigar.CheckPasswordAsync(User, model.Password);

					if (UserLogin)
					{
						var Result = await _SignInManager.CheckPasswordSignInAsync(User, model.Password, false);
						if (Result.Succeeded)
						{
							return RedirectToAction("Index", "Home");
						}
					}
					else
					{
						ModelState.AddModelError(string.Empty, "The Password Is Error");
					}
				}
				else
				{
					ModelState.AddModelError(string.Empty, "The Email Is Not Exsits");
				}
			}


			return View(model);
		}
		#endregion

		#region SignUot //////

		public async Task< IActionResult> SignOut()
		{
			await _SignInManager.SignOutAsync();
			return RedirectToAction(nameof(Login));
		}
		#endregion

		#region ResetPassword ////////


		public IActionResult ForgetPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task< IActionResult> ForgetPassword(ForgetPasswordViewModel model)
		{

			if (ModelState.IsValid)
			{
				var user = await _UserManigar.FindByEmailAsync(model.Email);

				if (user != null)
				{
					var token = await _UserManigar.GeneratePasswordResetTokenAsync(user);

					var ResetPasswordLink = Url.Action("ResetPassword" , "Account" , new {email = model.Email , Token= token }, Request.Scheme);

					var email = new Email()
					{
						To = user.Email,
						Supject = "Reseet Password",
						Body = ResetPasswordLink

					};

					EmailSettings.SendEmail(email);
					return RedirectToAction(nameof(ChekInpox));
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Not found Email ");
				}

			}
			return View(model);
		}

		public IActionResult ChekInpox()
		{
			return View();
		}

		public IActionResult ResetPassword(string email , string Token)
		{
			TempData["email"] = email;
			TempData["token"] = Token;

			return View();
		}
		[HttpPost]
		public async Task< IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
		string email=	TempData["email"] as string;
		string token=	TempData["token"] as string;

			var user = await _UserManigar.FindByEmailAsync(email);

		     var Result =	await _UserManigar.ResetPasswordAsync(user , token , model.NewPassword);
			if(Result.Succeeded)
			{
				return View(nameof(Login));
			}
			else
			{
				foreach(var error in Result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			return View(model);
		}

		#endregion


	}
}
