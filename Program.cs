using System.Net.Sockets;
using System.Text;

namespace HW_09_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 8888);
                NetworkStream stream = client.GetStream();

                Console.WriteLine("Enter 2 currencies to get the rate (for example: USD EURO): ");

                while (true)
                {
                    string input = Console.ReadLine();

                    if(input.ToLower() == "exit")
                    {
                        break;
                    }

                    byte[] data = Encoding.UTF8.GetBytes(input);
                    stream.Write(data, 0, data.Length);

                    byte[] byffer = new byte[1024];
                    int bytesRead = stream.Read(byffer, 0, byffer.Length);
                    string response = Encoding.UTF8.GetString(byffer,0,bytesRead);

                    Console.WriteLine($"Server response: {response}");
                }

                stream.Close();
                client.Close();
            }
            catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
