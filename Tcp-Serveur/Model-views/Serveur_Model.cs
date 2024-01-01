using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tcp_Serveur.Model;

namespace Tcp_Serveur.Model_views
{
   public class Serveur_Model: ObservableObject
    {
        private TcpClient? client;
        private Serveur? S ;
        private TcpListener? server;
        private NetworkStream? nwStream;


        public  Serveur? Se {
            get => S; set => S = value;
        }
        

        public Serveur_Model()
        {
              S = new Serveur("127.0.0.1", 8080);
            server = new TcpListener(IPAddress.Parse(S.IpAddress), S.Port);

        }
        // Inside Serveur_Model
      



        public void  Start()
		{
			server.Start();

            S.IsServerRunning = false;
            Task.Run(()=>AcceptClientConnections());
           
            MessageBox.Show("ok", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

            
        }
        private void AcceptClientConnections()
        {
            while (true)
            {
                 client = server.AcceptTcpClient();
                while (true)
                {
                  HandleClient();
                }
               
            }
        }
        public void SendMessage(string message)
        {
            byte[] bytesToSend = Encoding.ASCII.GetBytes(message);
             nwStream = client.GetStream();
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
        }
        private void HandleClient()
        {
            try
            {
                String? clientIp = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    S.ipclient = clientIp;
                });

                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                // Read incoming stream
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                // Convert the data received into a string
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                S.ReceivedMessage += dataReceived;
                S.ReceivedMessage += "--------------\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error handling client: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
