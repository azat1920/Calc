using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WpfClient
{
    public static class NetworkHelpers
    {
        /// <summary>
        /// Выполняет получение строки
        /// </summary>
        /// <param name="socket">Сокет, с установленным соедниением по TCP</param>
        /// <returns></returns>
        public static string TcpReceiveMessage(this Socket socket)
        {
            //буфер для получения сообщения
            var buffer = new byte[socket.ReceiveBufferSize];

            //строка-результат
            string message = string.Empty;

            //флажок, показывающий, завершена ли передача всего сообщения целиком
            bool receivedAll = false;

            do
            {
                //получаем данные в буфер, сохраняя количество реально полученных байт
                int receivedBytesCount = socket.Receive(buffer, buffer.Length, SocketFlags.None);

                //преобразовываем в строку 
                message += Encoding.ASCII.GetString(buffer, 0, receivedBytesCount);

                //проверяем, завершена ли передача данных (получили ли признак конца сообщения - '\0\0')
                receivedAll = IsEndOfMessage(buffer, receivedBytesCount);
                Thread.Sleep(10);
            } while (!receivedAll);

            return message.Substring(0, message.Length - 2);
        }

        /// <summary>
        /// Выполняет отправку строки через сокет
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="message"></param>
        public static void TcpSendMessage(this Socket socket, string message)
        {
            //буфер для отправляемого сообщения
            const int bufferSize = 1024;

            byte[] buffer = new byte[bufferSize];

            //количество байт во всём сообщении - нужно для вычисления смещения
            //относительно начала массива байт всего сообщения
            var totalMessageLength = Encoding.ASCII.GetByteCount(message);

            //количество байт, которое было отправлено
            int totalBytesSent = 0;

            do
            {
                //количество байт, которые необходимо получить из строки: 
                //если это "остаток" - т.е. меньше длины буфера - берём разность от всей длины сообщения и количества уже отправленных байт
                //иначе - это фрагмент, который целиком помещается в буфер, т.е. берём длину буфера.
                var bytesToEncode = totalMessageLength - totalBytesSent < buffer.Length
                                    ? totalMessageLength - totalBytesSent
                                    : buffer.Length;

                //выполняем получение массива байт из строки
                var count = Encoding.ASCII.GetBytes(message, totalBytesSent, bytesToEncode, buffer, 0);

                //выполняем отправку массива байт, увеличивая количество отправленных байт на соотв. значение
                totalBytesSent += socket.Send(buffer, 0, count, SocketFlags.None);


            } while (totalBytesSent < totalMessageLength);

            //отправляем признак конца сообщения
            socket.Send(new byte[] { 0, 0 });
            Thread.Sleep(10);
        }



        /// <summary>
        /// Метод для проверки сообщения на признак конца (два нуля)
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="received"></param>
        /// <returns></returns>
        private static bool IsEndOfMessage(byte[] buffer, int received)
        {
            for (int i = 0; i < Math.Min(buffer.Length, received); i++)
            {
                if (buffer[i] == 0)
                {
                    if (i > buffer.Length - 1)
                        continue;

                    if (buffer[i + 1] == 0)
                        return true;

                    //здесь есть один случай, который может возникнуть, хотя маловероятен.
                    //попробуйте догадаться и реализовать :)
                }
            }

            return false;
        }




    }
}
