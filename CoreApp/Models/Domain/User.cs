using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml;

namespace CoreApp.Models.Domain
{
	public class User
	{
		long Id { get; set; }	
		long UserId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
