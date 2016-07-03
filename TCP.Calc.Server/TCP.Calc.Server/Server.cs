using NetworkSamples.Model;
using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace TCP.Calc.Server
{
    class Server
    {
        static Socket socket;

        static void Main(string[] args)
        {
            try
            {
                var ip = IPAddress.Parse("127.0.0.1");
                int port = 11000;
                const int backlog = 4;

                //создаём сокет - работающий по протоколу TCP/IP
                using (socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {

                    var currentEndPoint = new IPEndPoint(IPAddress.Loopback, port);
                    socket.Bind(currentEndPoint);
                    socket.Listen(backlog);

                    Console.WriteLine("Listening...");

                    Socket client = null;

                    while (true)
                    {


                        client = socket.Accept();

                        Console.WriteLine("Client with ip {0} connected.", client.RemoteEndPoint);

                        try
                        {
                            Thread thread = new Thread(new ParameterizedThreadStart(Work));
                            thread.Start(client);
                        }
                        catch (Exception)
                        {

                        }
                    }



                }

            }
            catch (Exception) { }
            finally
            {
                Console.ReadKey();
            }

        }


        static void Work(object cl)
        {



            Socket client = (Socket)cl;
            try
            {
                List<double> list = new List<double>();
                list.Add(0);

                Info msg = new Info();
                string oper = "+";
                Operations op = new Operations();

                while (true)
                {


                    var message = client.TcpReceiveMessage();
                    WriteLogs(message, client.RemoteEndPoint);
                    Console.WriteLine("Receive from {0}: {1}", client.RemoteEndPoint, message.Substring(2));

                    if (message.StartsWith("> ") || message.StartsWith("@ #"))
                    {
                        if (message.StartsWith("@ #"))
                        {
                            oper = message.Substring(2);
                            list.Add(op.oper(oper, list, 0));
                        }
                        else
                        {
                            list.Add(op.oper(oper, list, Double.Parse(message.Substring(2))));
                        }
                        string str = msg.writeStep(list.Count - 1, list[list.Count - 1]);
                        client.TcpSendMessage(str);
                        Console.WriteLine("Send to {0}: {1}", client.RemoteEndPoint, str);
                    }
                    else
                    {
                        oper = message.Substring(2);
                        client.TcpSendMessage(oper);

                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Client with ip {0} disconnected.", client.RemoteEndPoint);
            }


        }

        static async void WriteLogs(string message, EndPoint endPoint)
        {
            using (StreamWriter sr = new StreamWriter(@"D:\labs\3 module\lab1\Calc\TCP.Calc.Server\TCP.Calc.Server\out.txt", true))
            {
                await sr.WriteAsync(String.Format("From {0}: {1}\n", endPoint.ToString(), message));
            }
        }

    } // class Server
}
