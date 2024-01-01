using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation_User_Serveur.BL.IUDATA
{
	public  interface IConversation
	{
		public void  AddConversation(Conversation conversation);
		public void RemoveConversation(Conversation conversation);
		public List<Conversation> GetAll();
	}
}
