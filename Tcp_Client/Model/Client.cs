using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tcp_Client.Model
{
    public class Client : ObservableObject
    {
        private TcpClient client;
        private Boolean Send;
        private string ip_serveur;
        private int port;
        private string message_client;
        private string message_server;
        public Boolean send { get => Send; set => SetProperty(ref Send, value); }

        public String Message_serveur{ get => message_server; set => SetProperty(ref message_server, value); }
        public String Message_client { get => message_client; set => SetProperty(ref message_client, value); }

        public string Ip
        {
            get => ip_serveur;
            set => SetProperty(ref ip_serveur, value);
        }
        public int Port
        {
            get => port;
            set => SetProperty(ref port, value);
        }

        public Client() {
            this.message_server = string.Empty;
            this.ip_serveur = string.Empty;
        }
    }
}
