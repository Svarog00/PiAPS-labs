using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
//client
namespace SocketTcpClient
{
    class Client
    {
        // адрес и порт сервера, к которому будем подключаться
        static int port = 8005; // порт сервера
        static string address = "25.124.119.240"; // адрес сервера

        static Thread Messages;

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Connecting...\n");

                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //подключаемся к удаленному хосту
                server.Connect(ipPoint);
                //получаем ключ дешифровки и шифровки
                int bytesOfPass = 0;
                byte[] passB = new byte[256];
                StringBuilder pass = new StringBuilder();
                do
                {
                    bytesOfPass = server.Receive(passB, passB.Length, 0);
                    pass.Append(Encoding.Unicode.GetString(passB, 0, bytesOfPass));
                }
                while (server.Available > 0);

                Console.Write("Completed! Welcome " + server.LocalEndPoint + "\n");

                Messages = new Thread(() => GettingMessages(server, pass.ToString())); //поток для обновления полученных сообщений
                Messages.Start();

                while (true)
                {
                    //Console.Write("Введите сообщение:");
                    string message = Console.ReadLine();

                    string codedMessage = Encode(message, pass.ToString()); //кодирование сообщения
                    byte[] data = Encoding.Unicode.GetBytes(codedMessage);
                    server.Send(data); //отправка на сервер

                    if (message == "/disconnect")
                        break;
                }
                // закрываем сокет
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }

        public static void GettingMessages(Socket server, string pass)
        {
            while(true)
            {
                // получаем ответ
                byte[] data = new byte[256]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байт

                do
                {
                    bytes = server.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes)); //получение закодированного сообщения
                }
                while (server.Available > 0);

                string tmpStr;
                tmpStr = Decode(builder.ToString(), pass); //декодирование полученного сообщения

                Console.WriteLine("\n" + tmpStr); //вывод на экран клиента

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