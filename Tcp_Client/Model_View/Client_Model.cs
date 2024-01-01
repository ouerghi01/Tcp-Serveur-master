using CommunityToolkit.Mvvm.ComponentModel;
using Conversation_User_Serveur.BL;
using Conversation_User_Serveur.BL.IUDATA;
using Conversation_User_Serveur.BL;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tcp_Client.Model;

namespace Tcp_Client.Model_View
{
   public class Client_Model : ObservableObject
    {
        private NetworkStream? networkStream;
		private readonly IConversation?  _ConversationDb;
		private Client c;
        public Client cl
        {
            get => c; set => c = value;
        }
        private  TcpClient? Client;
        public Client_Model() { 
            c= new Client();
            Client=new TcpClient();

		}
        public void Connection()
        {
            Client.Connect(c.Ip, c.Port);
            c.send = true;
            networkStream = Client.GetStream();
            
            Task.Run(() => ReceiveMessages());

            MessageBox.Show("connected", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private void ReceiveMessages()
        {

            while (true)
            {
                byte[] buffer = new byte[Client.ReceiveBufferSize];
                int bytesRead = networkStream.Read(buffer, 0, Client.ReceiveBufferSize);

                if (bytesRead > 0)
                {
                    string receivedMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                     c.Message_serveur+= receivedMessage;
                    c.Message_serveur += "---------------------\n";
                }
            }
        }
        public void SendMessage(string message)
        {
            try
			{  
                

				NetworkStream nwStream = Client.GetStream();
                byte[] bytesToSend = Encoding.ASCII.GetBytes(message);

                Console.WriteLine("Sending: " + message);
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);
				
                string ex = "good";
				MessageBox.Show($"Failed to send message: {ex}", "Error");

			}
			catch (Exception ex)
            {
                MessageBox.Show($"Failed to send message: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
