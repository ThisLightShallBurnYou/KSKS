using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UDPServer
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        int port = 12345; // Ваш порт
        UdpClient udpServer = new UdpClient(port);
        Console.WriteLine("Сервер запущений. Введіть команди:");

        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, port);

        try
        {
            while (true)
            {
                byte[] receivedData = udpServer.Receive(ref remoteEndPoint);
                string command = Encoding.ASCII.GetString(receivedData);

                // Тут ви можете викликати функцію для розбору команд та вивести результат в консоль
                Console.WriteLine($"Виконано команду: {command}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
        finally
        {
            udpServer.Close();
        }
    }
}
