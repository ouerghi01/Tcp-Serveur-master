using Conversation_Chat_Serveur.DAL;
using Conversation_User_Serveur.BL;
using Conversation_User_Serveur.BL.IUDATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tcp_Client.Model_View;

namespace Tcp_Client.Views
{
    /// <summary>
    /// Logique d'interaction pour Client_Views.xaml
    /// </summary>
    public partial class Client_Views : Window
	{

		public Client_Views()
        {
            InitializeComponent();
            this.DataContext = new Client_Model( );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Client_Model)DataContext).Connection();

        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Context context = new Context();
            try
            {
                var clientModel = (Client_Model)DataContext;

                if (clientModel != null)
                {
                    string message = clientModel.cl.Message_client;

                    if (!string.IsNullOrEmpty(message))
                    {   
                        clientModel.SendMessage(message);
						Conversation_User_Serveur.BL.Conversation conv = new Conversation_User_Serveur.BL.Conversation
						{
							IpServeurId = clientModel.cl.Ip,
							ServeurPort = clientModel.cl.Port,
							ServeurMessage = clientModel.cl.Message_serveur,
							IpClient = "",
							DateTime = DateTime.Now,
							ClientMessage = message


						};
						context.Conversations.Add(conv);
						context.SaveChanges();
						MessageBox.Show("Message sent successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Message cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("DataContext is not set correctly", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send message: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
