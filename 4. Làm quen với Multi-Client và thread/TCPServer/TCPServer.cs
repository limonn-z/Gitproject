using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CHUONG_4_1;
class TCP_Server
{
    static void ProcessClient(Socket client)
    {
        while (true)
        {
            byte[] bytes = new byte[1024];
            int bytesRead = client.Receive(bytes);
            if (bytesRead == 0)
            {
                Console.WriteLine("No response received from the client.");
                break;
            }
            string message = Encoding.UTF8.GetString(bytes, 0, bytesRead);
            string clientIp = ((IPEndPoint)client.RemoteEndPoint!).Address.ToString();
            Console.WriteLine($"Message from {clientIp}: {message}");
        }
        Console.WriteLine("Client has disconnected!");
    }

    public static void Main()
    {
        Socket server = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp 
        );
        IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 8000);
        server.Bind(endpoint);
        server.Listen(10);

        while (true)
        {
            Console.WriteLine("Server is waiting for client...");
            Socket client = server.Accept();
            Console.WriteLine("A client has connected!");

            Thread newThread = new Thread(() => ProcessClient(client));
            newThread.Start();
        }
        // server.Close();
    }
}