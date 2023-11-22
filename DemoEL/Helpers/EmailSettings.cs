using DemoDAL.Models;
using System.Net;
using System.Net.Mail;

namespace DemoEL.Helpers
{
	public static class EmailSettings
	{
		public static void SendEmail(Email email)
		{
			var Clinte = new SmtpClient("smtp.gmail.com" , 587);
			Clinte.EnableSsl = true;
			Clinte.Credentials = new NetworkCredential("omar01reda@gmail.com", "epjsegdskepdccfe");
			Clinte.Send("omar01reda@gmail.com", email.To, email.Supject, email.Body);
		}
	}
}
