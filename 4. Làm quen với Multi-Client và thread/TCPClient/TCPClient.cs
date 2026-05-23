using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CHUONG_4_2;
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

        Console.WriteLine("Connecting...");
        client.Connect(endPoint);
        Console.WriteLine("Connected to server!");

        while (true) {
            Console.Write("Please write your message: ");
            var message = Console.ReadLine(); 
            if (message == null || message == "")
            {
                Console.WriteLine("Leave the conversation.");
                break;
            } 
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            client.Send(bytes);
            Console.WriteLine("Sent message to Server!");
        }
        client.Close();
    }
}
