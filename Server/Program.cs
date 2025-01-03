//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Sockets;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace Server
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {


//            private TcpListener server;
//        private TcpClient client;



//        public void Start(int port)
//        {
//            server = new TcpListener(IPAddress.Any, port);
//            server.Start();

//            Console.WriteLine($"Server started on port {port}");
//            Console.WriteLine($"Local IP: {GetLocalIPAddress()}");

//            AcceptSingleClient();
//        }

//        private void AcceptSingleClient()
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

//                // Read a single message
//                int bytesRead = stream.Read(buffer, 0, buffer.Length);
//                if (bytesRead > 0)
//                {
//                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
//                    Console.WriteLine($"Received from {clientIP}: {message}");
//                    //
//                    if (message.Equals("yes\r\n", StringComparison.OrdinalIgnoreCase))
//                    {
//                        // Trigger the event
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
//                    if (message.Equals("yes\r\n", StringComparison.OrdinalIgnoreCase))
//                    {
//                        // Trigger the event
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



//    }
//}
//        //class Program
//        //{
//        //    static void Main()
//        //    {
//        //        TcpServer server = new TcpServer();
//        //        server.Start(8080);  // Start server on port 8080
//        //    }
//        //}
    

//}
