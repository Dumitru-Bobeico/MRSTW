using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatFlow.Web.ViewModels
{
	public class LoginViewModel
	{
		[Required, MinLength(5)]
		public string Username { get; set; }

        public string Email { get; set; }
        [Required, MinLength(5), DataType(DataType.Password)]
		public string Password { get; set; }
	}
}