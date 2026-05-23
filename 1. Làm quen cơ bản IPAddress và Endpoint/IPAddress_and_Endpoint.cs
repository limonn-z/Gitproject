using System;
using System.Net;
namespace CHUONG_1;

class Program
{
    public static void Main1()
    {
        // 1: Tạo địa chỉ IP 
        IPAddress ip = IPAddress.Parse("192.168.1.100");
        Console.WriteLine(ip);
        Console.WriteLine(ip.AddressFamily);

        // 2: Tạo endpoint (IP + Port)
        IPEndPoint endpoint = new IPEndPoint(ip, 8080);
        Console.WriteLine(endpoint);

        // 3: Tra cứu tên máy và IP chính máy bản thân 
        string laptopName = Dns.GetHostName();
        Console.WriteLine(laptopName);

        // 4: Lấy thông tin mạng của máy và in ra danh sách IP của máy bản thân 
        IPHostEntry hostEntry = Dns.GetHostEntry(laptopName);
        Console.WriteLine("Các địa chỉ IP trên máy bạn lần lượt là: ");
        foreach(IPAddress addr in hostEntry.AddressList)
        {
            Console.WriteLine($"{addr} -- {addr.AddressFamily}");
        }

        // 5: Địa chỉ đặc biệt
        Console.WriteLine($"\nLoopback (localhost): {IPAddress.Loopback}"); // 127.0.0.1 (tự nói với bản thân)
        Console.WriteLine($"Any: {IPAddress.Any}"); // 0.0.0.0 (lắng nghe tất cả card mạng, cho phép mọi Ip kết nối đến port bất kỳ)
    }
}

/* 
    _ Luồng hoạt động:
        Máy tính -> có IP -> lựa Port -> Tạo endPoint -> Server/Client kết nối 
*/
