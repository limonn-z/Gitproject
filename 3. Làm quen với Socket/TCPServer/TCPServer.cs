using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace CHUONG_3_1;

class TCP_Server
{
    public static void Main()
    {
    //----------------------------------------- Mở cửa
        // Bước 1: Tạo socket (giống như mua một cái điện thoại nhưng ko dùng đc)
        Socket server = new Socket(
            AddressFamily.InterNetwork, // Phiên bản địa chỉ IP (IPv4: InterNetwork)
            SocketType.Stream,          // Kiểu truyền dữ liệu (stream là kiểu truyền liên tục, đúng thứ tự)
            ProtocolType.Tcp            // Giao thức mạng 
        ); 

        // Bước 2: Tạo địa chỉ đầy đủ để tiếp nhận bất kì địa chỉ IP nào muốn kết nối
        IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 8000);

        // Bước 3: Cho socket gắn với địa chỉ cụ thể (server ngồi ở port này để nhận dữ liệu nếu có ai gửi đến)
        server.Bind(endpoint);

        // Bước 4: Bắt đầu cho socket lắng nghe (server đã biết chỗ ngồi thì bắt đầu chờ khách đến -- chỉ chờ tối đa 10 người)
        server.Listen(10);

    //----------------------------------------- Chờ khách
        // Bước 5: Đặt server trạng thái treo cho đến khi có client đến  
        Console.WriteLine("Server is waiting ...");
        Socket client = server.Accept();
        Console.WriteLine("A client has connected");
        
    //----------------------------------------- Tiếp khách
        // Bước 6: Nhận tin nhắn và chuyển đổi từ byte sang chữ 
        byte[] buffer = new byte[1024];
        int bytesRead = client.Receive(buffer);
        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine($"Server recieved message is: {message}");

    //----------------------------------------- Đóng cửa
        // Bước 7: Đóng server
        client.Close();
        server.Close();
    }  
}