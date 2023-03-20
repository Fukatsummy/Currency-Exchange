using System.Net.Sockets;
using System.Net;
using System.Text;

namespace CurrencyClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в приложение \"Курс валют\".");
            IPEndPoint serverPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            clientSocket.Connect(serverPoint);

            while (true)
            {
                if (clientSocket.Connected)
                {
                    Console.WriteLine("ВВедите валюту для конвертации");
                    Console.WriteLine("Валюта вводится двумя цифрами из списка через пробел.Первой указываем валюту, которую хотим конвертировать");
                    Console.WriteLine("1. EURO");
                    Console.WriteLine("2. USD");
                    Console.WriteLine("3. GBP");
                    string message = Console.ReadLine();
                    if (message != null)
                    {
                        if (message.Contains(' '))
                        {
                            string[] values = message.Split(" ");
                            values[0] = values[0].Trim();//удаляет лишние пробелы
                            values[1] = values[1].Trim();
                            clientSocket.Send(Encoding.UTF8.GetBytes(values[0] + " " + values[1] + " "));

                           // clientSocket.Receive();
                    }
                        else
                        {
                            Console.WriteLine("Просим соблюдать инструкции. Программа не обнаружила пробел в запросею");
                        }
                    }
                }
            }
        }
    }
}