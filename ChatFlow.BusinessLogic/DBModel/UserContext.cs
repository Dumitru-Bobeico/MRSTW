using System.Data.Entity;
using ChatFlow.Domains.Entities;

namespace ChatFlow.BusinessLogic.DBModel
{
	public class UserContext:DbContext
	{
		public UserContext():base("MRSTW3")
		{
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Chat> Chats { get; set; }
	}	
}
