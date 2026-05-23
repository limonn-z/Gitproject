// Hãy hình dung server là bảo vệ của một tòa chung cư 
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace CHUONG_2_1;

class TCP_Server{
    public static void Main()
    {
        // Bảo vệ mở cửa (server lắng nghe và chấp nhận mọi kết nối từ bất kỳ địa chỉ IP nào)
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 8000);
        TcpListener server = new TcpListener(endPoint);
        server.Start();
        Console.WriteLine("Server is waiting connect...");

        // Chờ khách (đặt server ở trạng thái chờ cho đến khi có ip của client kết nối đến server)
        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("Client found!");

        // Tiếp khách (server nhận tin nhắn từ client)
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024]; // Tạo một cái thùng chứa dữ liệu nhận về truyền dưới dạng byte 
        int bytesRead = stream.Read(buffer, 0, buffer.Length); // Nhận số byte chữ đọc được từ Client gửi qua 
        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead); // Chuyển byte sang chữ để đọc
        Console.WriteLine($"Server receive message is: {message}"); 

        // Đóng cửa (server đóng kết nối)
        stream.Close();
        client.Close(); // Không chờ khách nữa (tránh tràn RAM)
        server.Stop();
    }
}

