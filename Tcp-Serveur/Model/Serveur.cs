using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tcp_Serveur.Model
{
    public class Serveur: ObservableObject
    {
        private String ipaddress;
        private String ip_address_client;
        private int port;
        private string message;
        private string receivedMessage;
        private bool isServerRunning=true;
        public string ipclient { get => ip_address_client; set => SetProperty(ref ip_address_client, value); }
        public bool IsServerRunning
        {
            get => isServerRunning;
            set
            {
                if (SetProperty(ref isServerRunning, value, nameof(IsServerRunning)))
                {
                    OnPropertyChanged(nameof(CanStartServer));
                }
            }
        }
        public bool CanStartServer => !IsServerRunning;

        public string ReceivedMessage 
        { get => receivedMessage; 
          set => SetProperty(ref receivedMessage, value);
        }
        public string IpAddress
        {
            get => ipaddress;
            set => SetProperty(ref ipaddress, value);
        }

        public int Port
        {
            get => port;
            set => SetProperty(ref port, value);
        }

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }
       

        public Serveur(string ipaddress, int port)
        {
            this.ipaddress = ipaddress;
            this.port = port;
            this.message = string.Empty;
            this.ip_address_client = string.Empty;
        }
    }
}
