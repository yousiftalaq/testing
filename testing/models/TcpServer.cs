//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Sockets;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace testing.models
//{
//    public class TcpServer
//    {
//        private TcpListener server;
//        private TcpClient client;

//        public TcpServer(TcpListener server, TcpClient client)
//        {
//            this.server = server;
//            this.client = client;
//        }

//        public event Action OnIncrementReceived; // Event to notify Blazor component

//        public void Start(int port)
//        {
//            server = new TcpListener(IPAddress.Any, port);
//            server.Start();

//            Console.WriteLine($"Server started on port {port}");
//            Console.WriteLine($"Local IP: {GetLocalIPAddress()}");

//            AcceptSingleClient();
//        }

//        private void AcceptSingleClient( )
//        {
//            Console.WriteLine("Waiting for a client connection...");
//            client = server.AcceptTcpClient();
//            HandleClientCommunication(client);
//        }

//        private void HandleClientCommunication(TcpClient client)
//        {
//            NetworkStream stream = client.GetStream();
//            byte[] buffer = new byte[1024];


//            try
//            {
//                string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
//                Console.WriteLine($"Client connected from: {clientIP}");


//                //using (NetworkStream strea = client.GetStream())
//                //{
//                //    Console.WriteLine("Connected to server.");
//                //   // string message = "Hello, Arduino! can you approved for add Counter ? Yes or No";
//                //    byte[] data = Encoding.ASCII.GetBytes(message + "\n");
//                //    strea.Write(data, 0, data.Length);
//                //    Console.WriteLine("Message sent: " + message);
//                //}

//                // Read a single message
//                int bytesRead = stream.Read(buffer, 0, buffer.Length);
//                if (bytesRead > 0)
//                {
//                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
//                    Console.WriteLine($"Received from {clientIP}: {message}");
//                    //
//                    if (message.Equals("yes", StringComparison.OrdinalIgnoreCase))
//                    {
//                        // Trigger the event
//                        OnIncrementReceived?.Invoke();
//                    }

//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error: {ex.Message}");
//            }
//            finally
//            {
//                //client.Close();
//                //Console.WriteLine("Client disconnected");
//            }
//        }

//        public void sendTCPMessage(string message)
//        {
//            string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
//            Console.WriteLine($"Client connected from: {clientIP}");


//            using (NetworkStream strea = client.GetStream())
//            {
//                Console.WriteLine("Connected to server.");
//                // string message = "Hello, Arduino! can you approved for add Counter ? Yes or No";
//                byte[] data = Encoding.ASCII.GetBytes(message + "\n");
//                strea.Write(data, 0, data.Length);
//                Console.WriteLine("Message sent: " + message);
//            }
//        }

//        private string GetLocalIPAddress()
//        {
//            var host = Dns.GetHostEntry(Dns.GetHostName());
//            foreach (var ip in host.AddressList)
//            {
//                if (ip.AddressFamily == AddressFamily.InterNetwork)
//                {
//                    return ip.ToString();
//                }
//            }
//            return "127.0.0.1";
//        }

//        public void Stop()
//        {
//            client.Close();
//            server.Stop();
//        }




//        public void SendIncrementRequest()
//        {
//            NetworkStream stream = client.GetStream();
//            byte[] buffer = new byte[1024];

//            try
//            {
//                string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
//                Console.WriteLine($"Client connected from: {clientIP}");

//                // Read a single message
//                int bytesRead = stream.Read(buffer, 0, buffer.Length);
//                if (bytesRead > 0)
//                {
//                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
//                    Console.WriteLine($"Received from {clientIP}: {message}");
//                    //
//                    if (message.Equals("yes", StringComparison.OrdinalIgnoreCase))
//                    {
//                        // Trigger the event
//                        OnIncrementReceived?.Invoke();
//                    }

//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error: {ex.Message}");
//            }
//            finally
//            {
//                //client.Close();
//                //Console.WriteLine("Client disconnected");
//            }
//        }




//        public void SendMessage(string message)
//        {
//            TcpListener server = null;
//            TcpClient client = null;

//            try
//            {
//                server = new TcpListener(IPAddress.Any, 5050);
//                server.Start();
//                Console.WriteLine("Server started and waiting for client connections...");

//                client = server.AcceptTcpClient();
//                string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
//                Console.WriteLine($"Client connected from: {clientIP}");

//                using (NetworkStream stream = client.GetStream())
//                {
//                    // Send message to the client
//                    byte[] data = Encoding.ASCII.GetBytes(message + "\n");
//                    stream.Write(data, 0, data.Length);
//                    Console.WriteLine("Message sent: " + message);

//                    // Read response from client
//                    byte[] buffer = new byte[1024];
//                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
//                    if (bytesRead > 0)
//                    {
//                        string clientMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
//                        Console.WriteLine($"Received from {clientIP}: {clientMessage}");
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error: {ex.Message}");
//            }
//            finally
//            {
//                // Clean up resources
//                if (client != null)
//                {
//                    client.Close();
//                    Console.WriteLine("Client disconnected.");
//                }

//                if (server != null)
//                {
//                    server.Stop();
//                    Console.WriteLine("Server stopped.");
//                }
//            }
//        }

//    }

//}

#region new Change

using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace testing.models
{
    public class TcpServer
    {
        private TcpListener server;
        private TcpClient client;

        public TcpServer(TcpListener server, TcpClient client)
        {
            this.server = server;
            this.client = client;
        }

        public void StartServer(int port)
        {
            //if (server == null)
            //{
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                Console.WriteLine($"Server started on port {port}");
           // }
        }

        public void AcceptClient()
        {
            if (server != null)
            {
                Console.WriteLine("Waiting for client connection...");
                client = server.AcceptTcpClient();
                Console.WriteLine("Client connected");
            }
        }

      
        public void SendMessage(string message)
        {
            if (client != null)
            {
                JsonMessage jsonMessage = new JsonMessage()
                {
                    Message = message,
                };

                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.ASCII.GetBytes(JsonSerializer.Serialize( jsonMessage) + "\n");
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Message sent: " + jsonMessage);
            }
        }

        public void StopServer()
        {
            client?.Close();
            server?.Stop();
            Console.WriteLine("Server stopped");
        }


        #region Get Message
        public void GetMessage()
        {
            using (NetworkStream stream = client.GetStream())
            {
    

                // Read response from client
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    string clientMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received from : {clientMessage}");
                }
            }
        }
        #endregion get message 
    }
}


#endregion done changes 