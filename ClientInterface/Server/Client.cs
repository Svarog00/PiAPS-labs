using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;

namespace SocketTcpServer
{
    //Класс клиента на сервере для хранения данных о клиенте и получения от него сообщений для последующей отправки остальным.
    class Client
    {
        Socket clientSocket;
        string nickname;
        Thread Messages;

        public Client(string nickname, Socket clientSocket)
        {
            this.nickname = nickname;
            this.clientSocket = clientSocket;

            Messages = new Thread(() => GetMessage());
            Messages.Start();
        }

        public Socket CSocket
        {
            get { return clientSocket; }
        }

        public string Nickname
        {
            get { return nickname; }
        }

        //получение сообщения от клиента и последующая его отправка другим клиентам
        void GetMessage()
        {
            StringBuilder builder = new StringBuilder();
            byte[] data = new byte[256]; // буфер для получаемых данных
            while(clientSocket.Connected)
            {
                do
                {
                    try
                    {
                        int bytes = clientSocket.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        builder.Append("/disconnect");
                        break;
                    }
                }
                while (clientSocket.Available > 0);

                Console.WriteLine(nickname + ": " + builder);

                string str = nickname + ": " + builder; //создание строки "Клиент: (сообщение)"
                byte[] strB = Encoding.Unicode.GetBytes(str);
                ServerClass.Distribution(strB);

                if (builder.ToString() == "/disconnect")
                {
                    // отключение клиента
                    clientSocket.Disconnect(true);
                    clientSocket.Close();
                    ServerClass.DisconnectClient(this);
                }
                builder.Clear(); //очистка буфера StringBuilder
            }
        }
    }
}
