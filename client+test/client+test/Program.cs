using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace CSCS1;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        string serverIP = "127.0.0.1"; // IP-адреса сервера
        int serverPort = 12345; // Порт сервера

        UdpClient udpClient = new UdpClient();
        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);

        while (true)
        {
            Console.WriteLine("Оберіть команду:");
            Console.WriteLine("1. Clear Display");
            Console.WriteLine("2. Draw Pixel");
            Console.WriteLine("3. Draw Line");
            Console.WriteLine("4. Draw Rectangle");
            Console.WriteLine("5. Fill Rectangle");
            Console.WriteLine("6. Draw Ellipse");
            Console.WriteLine("7. Fill Ellipse");
            Console.WriteLine("8. Draw Circle");
            Console.WriteLine("9. Fill Circle");
            Console.WriteLine("10. Draw Rounded Rectangle");
            Console.WriteLine("11. Fill Rounded Rectangle");
            Console.WriteLine("12. Draw Text");
            Console.WriteLine("13. Draw Image");
            Console.WriteLine("14. Set Orientation");
            Console.WriteLine("15. Get Width");
            Console.WriteLine("16. Get Height");
            Console.WriteLine("0. Вийти");

            int choice = GetUserChoice();

            switch (choice)
            {
                case 1:
                    SendClearDisplayCommand(udpClient, serverEndPoint);
                    break;
                case 2:
                    SendDrawPixelCommand(udpClient, serverEndPoint);
                    break;
                case 3:
                    SendDrawLineCommand(udpClient, serverEndPoint);
                    break;
                case 4:
                    SendDrawRectangleCommand(udpClient, serverEndPoint);
                    break;
                case 5:
                    SendFillRectangleCommand(udpClient, serverEndPoint);
                    break;
                case 6:
                    SendDrawEllipseCommand(udpClient, serverEndPoint);
                    break;
                case 7:
                    SendFillEllipseCommand(udpClient, serverEndPoint);
                    break;
                case 8:
                    SendDrawCircleCommand(udpClient, serverEndPoint);
                    break;
                case 9:
                    SendFillCircleCommand(udpClient, serverEndPoint);
                    break;
                case 10:
                    SendDrawRoundedRectangleCommand(udpClient, serverEndPoint);
                    break;
                case 11:
                    SendFillRoundedRectangleCommand(udpClient, serverEndPoint);
                    break;
                case 12:
                    SendDrawTextCommand(udpClient, serverEndPoint);
                    break;
                case 13:
                    SendDrawImageCommand(udpClient, serverEndPoint);
                    break;
                case 14:
                    SendSetOrientationCommand(udpClient, serverEndPoint);
                    break;
                case 15:
                    SendGetWidthCommand(udpClient, serverEndPoint);
                    break;
                case 16:
                    SendGetHeightCommand(udpClient, serverEndPoint);
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static int GetUserChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Невірний ввід. Введіть число зі списку вище.");
        }
        return choice;
    }

    public static void SendCommand(UdpClient udpClient, IPEndPoint serverEndPoint, string commandToSend)
    {
        try
        {
            byte[] data = Encoding.ASCII.GetBytes(commandToSend);
            udpClient.Send(data, data.Length, serverEndPoint);
            Console.WriteLine("Команда надіслана на сервер: " + commandToSend);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }

    public static void SendClearDisplayCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть колір: ");
        string color = Console.ReadLine();
        string command = "clear display: " + color;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendDrawPixelCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть x0: ");
        int x0 = GetUserInputInt();
        Console.Write("Введіть y0: ");
        int y0 = GetUserInputInt();
        Console.Write("Введіть колір: ");
        string color = Console.ReadLine();

        string command = "draw pixel: " + x0 + ", " + y0 + ", " + color;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendDrawLineCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть x0: ");
        int x0 = GetUserInputInt();
        Console.Write("Введіть y0: ");
        int y0 = GetUserInputInt();
        Console.Write("Введіть x1: ");
        int x1 = GetUserInputInt();
        Console.Write("Введіть y1: ");
        int y1 = GetUserInputInt();
        Console.Write("Введіть колір: ");
        string color = Console.ReadLine();

        string command = "draw line: " + x0 + ", " + y0 + ", " + x1 + ", " + y1 + ", " + color;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendDrawRectangleCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть x0: ");
        int x0 = GetUserInputInt();
        Console.Write("Введіть y0: ");
        int y0 = GetUserInputInt();
        Console.Write("Введіть ширину: ");
        int w = GetUserInputInt();
        Console.Write("Введіть висоту: ");
        int h = GetUserInputInt();
        Console.Write("Введіть колір: ");
        string color = Console.ReadLine();

        string command = "draw rectangle: " + x0 + ", " + y0 + ", " + w + ", " + h + ", " + color;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendFillRectangleCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть x0: ");
        int x0 = GetUserInputInt();
        Console.Write("Введіть y0: ");
        int y0 = GetUserInputInt();
        Console.Write("Введіть ширину: ");
        int w = GetUserInputInt();
        Console.Write("Введіть висоту: ");
        int h = GetUserInputInt();
        Console.Write("Введіть колір: ");
        string color = Console.ReadLine();

        string command = "fill rectangle: " + x0 + ", " + y0 + ", " + w + ", " + h + ", " + color;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendDrawEllipseCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть x0: ");
        int x0 = GetUserInputInt();
        Console.Write("Введіть y0: ");
        int y0 = GetUserInputInt();
        Console.Write("Введіть радіус по x: ");
        int radius_x = GetUserInputInt();
        Console.Write("Введіть радіус по y: ");
        int radius_y = GetUserInputInt();
        Console.Write("Введіть колір: ");
        string color = Console.ReadLine();

        string command = "draw ellipse: " + x0 + ", " + y0 + ", " + radius_x + ", " + radius_y + ", " + color;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendFillEllipseCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть x0: ");
        int x0 = GetUserInputInt();
        Console.Write("Введіть y0: ");
        int y0 = GetUserInputInt();
        Console.Write("Введіть радіус по x: ");
        int radius_x = GetUserInputInt();
        Console.Write("Введіть радіус по y: ");
        int radius_y = GetUserInputInt();
        Console.Write("Введіть колір: ");
        string color = Console.ReadLine();

        string command = "fill ellipse: " + x0 + ", " + y0 + ", " + radius_x + ", " + radius_y + ", " + color;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendDrawCircleCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть x0: ");
        int x0 = GetUserInputInt();
        Console.Write("Введіть y0: ");
        int y0 = GetUserInputInt();
        Console.Write("Введіть радіус: ");
        int radius = GetUserInputInt();
        Console.Write("Введіть колір: ");
        string color = Console.ReadLine();

        string command = "draw circle: " + x0 + ", " + y0 + ", " + radius + ", " + color;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendFillCircleCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть x0: ");
        int x0 = GetUserInputInt();
        Console.Write("Введіть y0: ");
        int y0 = GetUserInputInt();
        Console.Write("Введіть радіус: ");
        int radius = GetUserInputInt();
        Console.Write("Введіть колір: ");
        string color = Console.ReadLine();

        string command = "fill circle: " + x0 + ", " + y0 + ", " + radius + ", " + color;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendDrawRoundedRectangleCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть x0: ");
        int x0 = GetUserInputInt();
        Console.Write("Введіть y0: ");
        int y0 = GetUserInputInt();
        Console.Write("Введіть ширину: ");
        int w = GetUserInputInt();
        Console.Write("Введіть висоту: ");
        int h = GetUserInputInt();
        Console.Write("Введіть радіус: ");
        int radius = GetUserInputInt();
        Console.Write("Введіть колір: ");
        string color = Console.ReadLine();

        string command = "draw rounded rectangle: " + x0 + ", " + y0 + ", " + w + ", " + h + ", " + radius + ", " + color;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendFillRoundedRectangleCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть x0: ");
        int x0 = GetUserInputInt();
        Console.Write("Введіть y0: ");
        int y0 = GetUserInputInt();
        Console.Write("Введіть ширину: ");
        int w = GetUserInputInt();
        Console.Write("Введіть висоту: ");
        int h = GetUserInputInt();
        Console.Write("Введіть радіус: ");
        int radius = GetUserInputInt();
        Console.Write("Введіть колір: ");
        string color = Console.ReadLine();

        string command = "fill rounded rectangle: " + x0 + ", " + y0 + ", " + w + ", " + h + ", " + radius + ", " + color;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendDrawTextCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть x0: ");
        int x0 = GetUserInputInt();
        Console.Write("Введіть y0: ");
        int y0 = GetUserInputInt();
        Console.Write("Введіть колір: ");
        string color = Console.ReadLine();
        Console.Write("Введіть номер шрифту: ");
        int fontNumber = GetUserInputInt();
        Console.Write("Введіть довжину тексту: ");
        int length = GetUserInputInt();
        Console.Write("Введіть текст: ");
        string text = Console.ReadLine();

        string command = "draw text: " + x0 + ", " + y0 + ", " + color + ", " + fontNumber + ", " + length + ", " + text;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendDrawImageCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть x0: ");
        int x0 = GetUserInputInt();
        Console.Write("Введіть y0: ");
        int y0 = GetUserInputInt();
        Console.Write("Введіть ширину: ");
        int w = GetUserInputInt();
        Console.Write("Введіть висоту: ");
        int h = GetUserInputInt();
        Console.Write("Введіть дані (data_length = w * h * sizeof(color)): ");
        string data = Console.ReadLine();

        string command = "draw image: " + x0 + ", " + y0 + ", " + w + ", " + h + ", " + data;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendSetOrientationCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть орієнтацію (0=0, 1=90, 2=180, 3=270): ");
        int orientation = GetUserInputInt();

        string command = "set orientation: " + orientation;
        SendCommand(udpClient, serverEndPoint, command);
    }

    public static void SendGetWidthCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть ширіну: ");
        int width = GetUserInputInt();

        string command = "get width: " + width;
        try
        {
            byte[] data = Encoding.ASCII.GetBytes(command);
            udpClient.Send(data, data.Length, serverEndPoint);
            Console.WriteLine("Прийнято команду: " + command);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }

    public static void SendGetHeightCommand(UdpClient udpClient, IPEndPoint serverEndPoint)
    {
        Console.Write("Введіть висоту: ");
        int height = GetUserInputInt();

        string command = "get height: " + height;
        try
        {
            byte[] data = Encoding.ASCII.GetBytes(command);
            udpClient.Send(data, data.Length, serverEndPoint);
            Console.WriteLine("Прийнято команду: " + command);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }

    public static int GetUserInputInt()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Невірний ввід. Введіть ціле число.");
        }
        return input;
    }
}
