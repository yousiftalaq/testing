using System.Net.Sockets;
using System.Text;

public class Signal
{
    public async Task SendingSignalAsync()
    {
        string serverIp = "192.168.137.235"; // Replace with Arduino's IP
        int port = 5050; // Match the port used in Arduino sketch

        try
        {
            using (TcpClient client = new TcpClient())
            {
                client.ReceiveTimeout = 5000;
                client.SendTimeout = 5000;

                await client.ConnectAsync(serverIp, port);
                Console.WriteLine("Connected to server.");

                using (NetworkStream stream = client.GetStream())
                {
                    string message = "Hello, Arduino! Can you approve adding Counter? Yes or No";
                    byte[] data = Encoding.ASCII.GetBytes(message + "\n");
                    await stream.WriteAsync(data, 0, data.Length);
                    Console.WriteLine("Message sent: " + message);

                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    Console.WriteLine("Response: " + response);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
