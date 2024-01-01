using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation_User_Serveur.BL
{
	public  class Conversation
	{   public int ConversationId { get; set; }	
		public string IpServeurId { get; set; }
		public int ServeurPort { get; set; }
		public string ServeurMessage { get;set; }
		public string  IpClient { get; set;}
		public DateTime DateTime { get; set; }
		public string ClientMessage { get;set; }
	}
}
