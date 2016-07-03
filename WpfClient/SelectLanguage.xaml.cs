using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfClient
{
    /// <summary>
    /// Логика взаимодействия для SelectLanguage.xaml
    /// </summary>
    public partial class SelectLanguage : Window
    {
        public SelectLanguage()
        {
           
            InitializeComponent();
            ChechBoxLanguagess.SelectedIndex = 0;

        }

        void SelectLanguage_Closing(object sender, CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String str = ChechBoxLanguagess.Text;
            if (str == "Русский")
            {
                MainWindow.language = "ru-Ru";
            }
            else
            {
                MainWindow.language = "en-US";
            }

            this.Close();
        }

        


        
        
    }
}
