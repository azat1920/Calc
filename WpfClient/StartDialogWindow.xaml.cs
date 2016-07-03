using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfClient
{
    /// <summary>
    /// Логика взаимодействия для StartDialogWindow.xaml
    /// </summary>
    public partial class StartDialogWindow : Window
    {
        
            
        public StartDialogWindow()
        {   
           
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(MainWindow.language);
            InitializeComponent();
                
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        void StartDialogWindow_Close(object sender, CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string s1 = tbIp.Text;
                string s2 = tbPort.Text;

                if (s1.Length > 0 && s2.Length > 0)
                {
                        
                        Ip.ip = IPAddress.Parse(s1);
                        Ip.port = int.Parse(s2);

                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Connecting ERROR!!!");
                Environment.Exit(0);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void TextBlock_IsEnabledChanged_3(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }

    public static class Ip
    {
        public static IPAddress ip { get; set; }

        public static int port { get; set; }

        public static string mess = "Пример";

       
    }

   
  
        



}
