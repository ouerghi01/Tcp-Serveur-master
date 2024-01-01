using Conversation_Chat_Serveur.DAL;
using Conversation_User_Serveur.BL;
using Conversation_User_Serveur.BL.IUDATA;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Service
{
	public class IConversation_Do : IConversation
	{
		private readonly Context? _context;
		public IConversation_Do( ) {
			_context = new Context();
		}

		public void AddConversation(Conversation_User_Serveur.BL.Conversation conversation)
		{
			
			_context.Conversations.Add(conversation);
			_context.SaveChanges();
		}

		public List<Conversation_User_Serveur.BL.Conversation> GetAll()
		{
			throw new NotImplementedException();
		}

		public void RemoveConversation(Conversation_User_Serveur.BL.Conversation conversation)
		{
			throw new NotImplementedException();
		}
	}
}
