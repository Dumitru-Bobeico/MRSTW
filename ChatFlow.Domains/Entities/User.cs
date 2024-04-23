using System;

namespace ChatFlow.Domains.Entities
{
	public class User
	{
		public int Id { get; set; }

		//[Required, MinLength(5), Column(TypeName = "VARCHAR")]
		public string Username { get; set; } = string.Empty;

		//[Required, MinLength(5), DataType(DataType.Password)]
		public string Password { get; set; }


		//[EmailAddress, Column(TypeName = "VARCHAR"), Required]
		public string Email { get; set; }

		//[ScaffoldColumn(false)]
		public string Imageurl { get; set; }

		//[ScaffoldColumn(false)]
		public DateTime? CreatedOn { get; set; }
	}
}