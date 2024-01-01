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
using Tcp_Serveur.Model_views;

namespace Tcp_Serveur.Views
{
    /// <summary>
    /// Logique d'interaction pour Serveur_Views.xaml
    /// </summary>
    public partial class Serveur_Views : Window
    {
        public Serveur_Views()
        {
            InitializeComponent();
           
            
            this.DataContext = new Serveur_Model();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Serveur_Model)DataContext).Start();
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var serveur = (Serveur_Model)DataContext;

                if (serveur != null)
                {
                    string message = serveur.Se.Message;

                    if (!string.IsNullOrEmpty(message))
                    {
                        serveur.SendMessage(message);
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
