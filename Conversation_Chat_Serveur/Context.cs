using Conversation_User_Serveur.BL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation_Chat_Serveur.DAL
{
	public class Context : DbContext
	{
		public DbSet<Conversation> ?Conversations{get;set;}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Serveur_Client;Integrated Security = true");
		}
	}
}
