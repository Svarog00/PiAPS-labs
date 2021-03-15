using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;
using System.Security.Cryptography;
using System.IO;
//server
namespace SocketTcpServer
{
    class Server
    {
        static Thread Messages;

        static int numOfClients = 5;
        static int currentClients = 0;
        static Socket[] handlers = new Socket[numOfClients];
        static int port = 8005; // порт для приема входящих запросов
        static string pass = "bollocks";

        static void Main(string[] args)
        {
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("25.124.119.240"), port);

            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Messages = new Thread(() => Chatting());
            Messages.Start();

            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // начинаем прослушивание
                listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    //Socket handler = listenSocket.Accept();
                    handlers[currentClients] = listenSocket.Accept();
                    Console.WriteLine(handlers[currentClients].RemoteEndPoint + " connected"); //вывод о том, что кто-то подключился
                    byte[] data = Encoding.Unicode.GetBytes(pass); 
                    handlers[currentClients].Send(data);//отправка подключенному клиенту пароля для декодирования
                    currentClients++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Chatting()
        {
            while(true)
            {
                // получаем сообщение
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байтов
                byte[] data = new byte[256]; // буфер для получаемых данных

                for (int i = 0; i < currentClients; i++)
                {
                    do
                    {
                        bytes = handlers[i].Receive(data); //получение сообщения
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handlers[i].Available > 0);

                    string tmpStr;
                    tmpStr = Decode(builder.ToString(), pass); //дешифровка сообщения
                    Console.WriteLine(handlers[i].RemoteEndPoint + ": " + tmpStr); 

                    string str = handlers[i].RemoteEndPoint + ": " + tmpStr; //создание строки "Клиент: (сообщение)"
                    str = Encode(str, pass); //кодировка строки
                    byte[] strB = Encoding.Unicode.GetBytes(str);
                    Distribution(handlers, strB, i); //рассылка всем остальным пользователям

                    // отправляем ответ
                    //string message = "ваше сообщение доставлено";
                    //data = Encoding.Unicode.GetBytes(message);
                    //handlers[i].Send(data);
                    if (tmpStr == "/disconnect")
                    {
                        // отключение клиента
                        //handlers[i].Shutdown(SocketShutdown.Both);
                        handlers[i].Disconnect(true);
                        handlers[i].Close();
                        currentClients--;
                    }
                    builder.Clear(); //очистка буфера StringBuilder
                }
            }
        }

        static void Distribution(Socket[] handlers, byte[] data, int currentUser)
        {
            for (int i = 0; i < currentClients; i++)
            {
                if(i == currentUser)
                {
                    continue;
                }
                handlers[i].Send(data);
            }
        }


        public static string Encode(string ishText, string pass,
               string sol = "geezer", string cryptographicAlgorithm = "SHA1",
               int passIter = 2, string initVec = "a8doSuDitOz1hZe#",
               int keySize = 256)
        {
            if (string.IsNullOrEmpty(ishText))
                return "";

            byte[] initVecB = Encoding.ASCII.GetBytes(initVec);
            byte[] solB = Encoding.ASCII.GetBytes(sol);
            byte[] ishTextB = Encoding.UTF8.GetBytes(ishText);

            PasswordDeriveBytes derivPass = new PasswordDeriveBytes(pass, solB, cryptographicAlgorithm, passIter); //формироватор ключа из пароля pass и соли
            byte[] keyBytes = derivPass.GetBytes(keySize / 8);
            RijndaelManaged symmK = new RijndaelManaged(); //сам шифратор 
            symmK.Mode = CipherMode.CBC; //блочный шифр

            byte[] cipherTextBytes = null;

            using (ICryptoTransform encryptor = symmK.CreateEncryptor(keyBytes, initVecB)) //создание симметричного шифратора с заданным ключом
            {
                using (MemoryStream memStream = new MemoryStream()) //поток с резервным копированием в памяти
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write)) //поток для шифрования
                    {
                        cryptoStream.Write(ishTextB, 0, ishTextB.Length);
                        cryptoStream.FlushFinalBlock();
                        cipherTextBytes = memStream.ToArray(); //результат шифрования
                        memStream.Close();
                        cryptoStream.Close();
                    }
                }
            }

            symmK.Clear();
            return Convert.ToBase64String(cipherTextBytes);
        }

        //метод дешифрования строки
        public static string Decode(string ciphText, string pass,
               string sol = "geezer", string cryptographicAlgorithm = "SHA1",
               int passIter = 2, string initVec = "a8doSuDitOz1hZe#",
               int keySize = 256)
        {
            if (string.IsNullOrEmpty(ciphText))
                return "";

            byte[] initVecB = Encoding.ASCII.GetBytes(initVec);
            byte[] solB = Encoding.ASCII.GetBytes(sol);
            byte[] cipherTextBytes = Convert.FromBase64String(ciphText); //зашифрованое сообщение

            PasswordDeriveBytes derivPass = new PasswordDeriveBytes(pass, solB, cryptographicAlgorithm, passIter); //формироватор ключа из пароля pass и соли
            byte[] keyBytes = derivPass.GetBytes(keySize / 8);

            RijndaelManaged symmK = new RijndaelManaged();
            symmK.Mode = CipherMode.CBC;

            byte[] plainTextBytes = new byte[cipherTextBytes.Length]; //результатик
            int byteCount = 0;

            using (ICryptoTransform decryptor = symmK.CreateDecryptor(keyBytes, initVecB))
            {
                using (MemoryStream memStream = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read))
                    {
                        byteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                        memStream.Close();
                        cryptoStream.Close();
                    }
                }
            }

            symmK.Clear();
            return Encoding.UTF8.GetString(plainTextBytes, 0, byteCount);
        }
    }
}