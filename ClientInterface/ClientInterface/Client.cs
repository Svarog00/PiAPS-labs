using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientInterface
{
    class Client
    {
        private Socket server;
        private IPEndPoint ipPoint;
        private bool isConnected = false;

        //Адрес и порт сервера, к которому происходит подключение при создании экземпляра класса
        //РичТекстБокс - текстовое поле, в которое происходит ввод сообщений
        //ТекстБокс с ником, который отправляется на сервер для хранения клиента
        public Client(string address, int port, RichTextBox richTextBox, TextBox nicknameTextBox)
        {
            try
            {
                ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Connect(ipPoint);
            
                string message = nicknameTextBox.Text;
                byte[] data = Encoding.Unicode.GetBytes(message);
                server.Send(data); //отправка на сервер
            
                richTextBox.AppendText($"Completed! Welcome to {server.LocalEndPoint} \n");

                isConnected = true;
                GetMessagesAsync(server, richTextBox);
            }
            catch(Exception e)
            {
                richTextBox.AppendText(e.Message);
            }
        }
        //Асинхронная функция для получения сообщение от сервера
        //Сокет для сервера, откуда получаются сообщения
        //РичТекстБокс - поле куда выводятся сообщения
        private async void GetMessagesAsync(Socket server, RichTextBox richTextBox)
        {
            await Task.Run(() => GetMessages(server, richTextBox));
        }

        private void GetMessages(Socket server, RichTextBox richTextBox)
        {
            while (isConnected)
            {
                // получаем ответ
                byte[] data = new byte[256]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                do
                {
                    int bytes = server.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes)); //получение закодированного сообщения
                }
                while (server.Available > 0);
                richTextBox.Invoke(new MethodInvoker(() => { richTextBox.AppendText($"\n{builder}"); }));
            }
        }

        public void Disconnect(RichTextBox richText)
        {
            if(isConnected)
            {
                string message = "/disconnect";
                byte[] data = Encoding.Unicode.GetBytes(message);
                server.Send(data); //отправка на сервер
                richText.AppendText($"Goodbye Y_Y");
                isConnected = false;
            }
        }
        //Отправка сообщения серверу 
        public void SendMessage(TextBox textBox)
        {
            if(isConnected)
            {
                string message = textBox.Text;
                byte[] data = Encoding.Unicode.GetBytes(message);
                server.Send(data);
            }
        }
    }
}
