using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace WpfClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int i = 1;
        public static string language = "en-US";
        private string text = null;
        private static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        

        public MainWindow()

        {

            SelectLanguage sl = new SelectLanguage();
            sl.ShowDialog();
            StartDialogWindow dw = new StartDialogWindow();
            dw.ShowDialog();
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(language);
            
            InitializeComponent();
               
               try
               {
                   socket.Connect(Ip.ip, Ip.port);
               }
               catch (Exception)
               {
                   MessageBox.Show("Connecting ERROR!!!","ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                   Environment.Exit(0);
               }
               
           
            
            tb.Focus();
            Thread t = new Thread(new ThreadStart(Work));
            t.Start();

        }



        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            text = tb.Text;
            tb.Clear();
            
        }



        void Work()
        {
            try
            {
                
                Info msg = new Info();
                Reader reader = new Reader();
                
                foreach (var item in msg.Inf(language))
                {
                    ChangeListBox(item);
                }


                while (true)
                {
                    

                    
                    string str = "";
                    //в цикле осуществляем приём и получение сообщений.
                    while (true)
                    {   
                        var s = (i == 1) ? "> " : "@ ";
                        ChangeTextBlock(Oper,s);

                        while (true)
                        {
                        
                        while (text == null) { }
                        str = text;
                        Ip.mess = text;
                        

                        if (i == 1)
                        {
                            do
	                    {
	                          str = reader.readNum(text);
                              
	                        } while (str.Equals(""));      
                        }
                        else
	                        {
                            do
	                        {
	                          str = reader.readOper(text);
	                        } while (str.Equals("0"));   
	                        }

                        break;
                        }

                        

                        socket.TcpSendMessage(s + str);

                        
                        if (str.Equals("q"))
                        {
                            System.Environment.Exit(0);
                        }

                        //ChangeListBox(text);
                        

                        if (text.StartsWith("#"))
                        {
                            i *= -1;
                        }
                        

                        var result = socket.TcpReceiveMessage();
                        if (result.StartsWith("a"))
                        {
                            ChangeListBox(result);
                        }

                        
                        i *= -1;
                        
                    }
                }





            }
            catch (Exception)
            {
            }




        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }

        public void ChangeListBox(string s)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                //обновление UI           
                TextBlock tb = new TextBlock();
                tb.Text = s;
                List.Items.Add(tb);
                List.SelectedIndex = List.Items.Count - 1;

            }), null);

            text = null;
        }
        public void ChangeTextBlock(TextBlock t, string s)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                //обновление UI           
                t.Text = s;

            }), null);

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           System.Environment.Exit(0);
        }
        private void List_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (List.SelectedItem != null && List.SelectedIndex > 7)
            {
                TextBlock tb = (TextBlock)List.SelectedItem;
                if (i == -1)
                {
                    string s = tb.Text;
                    s = "#" + s.Substring(s.IndexOf("[") + 1, s.IndexOf("]") - s.IndexOf("[") - 1);

                    socket.TcpSendMessage("@ " + s);
                    if (s.StartsWith("#")) i *= -1;
                    var result = socket.TcpReceiveMessage();
                    if (result.StartsWith("a")) ChangeListBox(result);
                    i *= -1;
                    UpdateScrollBar(List);
             
                }
            }
        }
        private void UpdateScrollBar(ListBox listBox)
        {
            if (listBox != null)
            {
                var border = (Border)VisualTreeHelper.GetChild(listBox, 0);
                var scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                scrollViewer.ScrollToBottom();
            }

        }

        private ICommand _exit;

        public ICommand ExitProg
        {
            get { return _exit ?? (_exit = new RelayCommand(() => System.Environment.Exit(0))); } 
        }

    }

  
}
