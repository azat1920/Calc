using System;
using System.Net;
using System.Net.Sockets;
using NetworkSamples.Model;
using System.Threading;

namespace TCP.Calc.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var targetIp = IPAddress.Parse("127.0.0.1");
                var port = 11000;
                Info msg = new Info();
                Reader reader = new Reader();

                //создаём сокет - работающий по протоколу TCP/IP
                using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {

                    //подключаемся к серверу
                    socket.Connect(targetIp, port);
                    msg.writeInf();
                    int i = 1;
                    //в цикле осуществляем приём и получение сообщений.
                    while (true)
                    {

                        var s = (i == 1) ? "> " : "@ ";

                        // Console.Write(s);

                        string str = (i == -1) ? reader.readOper() : reader.readNum();
                        if (str.Equals("q"))
                        {
                            break;
                        }


                        //вызываем extension-метод из NetworkSamples.Model.NetworkHelpers
                        socket.TcpSendMessage(s + str);

                        if (str.StartsWith("#"))
                        {
                            i *= -1;
                        }


                        var result = socket.TcpReceiveMessage();
                        if (result.StartsWith("a"))
                        {
                           Console.WriteLine("Response:" + result); 
                        }
                        




                        i *= -1;
                    }

                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}

