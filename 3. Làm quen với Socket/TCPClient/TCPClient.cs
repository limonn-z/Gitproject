using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CHUONG_3_2;
class TCP_Client
{
    public static void Main()
    {
        Socket client = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp
        );

        IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, 8000);
        client.Connect(endPoint);
        Console.WriteLine("Connected to Server!");

        string message = "Hello";
        byte[] bytes = Encoding.UTF8.GetBytes(message);
        client.Send(bytes);
        Console.WriteLine($"Sent message is: {message}");

        client.Close();
    }
}