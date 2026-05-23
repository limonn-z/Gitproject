using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CHUONG_2_2;
class TCP_Client
{
    public static void Main()
    {
        // Gõ cửa (Client muốn kết nối đến server)
        TcpClient client = new TcpClient();
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
        client.Connect(endPoint);
        Console.WriteLine("Connected to server");

        // Gửi tin nhắn đến server
        NetworkStream stream = client.GetStream();
        string message = "Hello world";
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        stream.Write(buffer, 0, buffer.Length);
        Console.WriteLine($"Sent message: {message}");

        // Ra về (Đóng kết nối)
        stream.Close(); // Đóng đường truyền liên lạc (ống dẫn) trước 
        client.Close();
    }
}