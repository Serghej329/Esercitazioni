using System;
using System.Net.Sockets;
using System.Text;

public class Client
{
    public void StartClient(string serverIP, int port)
    {
        using (var client = new TcpClient(serverIP, port))
        {
            using (var stream = client.GetStream())
            {
                Console.WriteLine("Connesso al server.");
                string messageToSend = Console.ReadLine();

                while (!string.IsNullOrEmpty(messageToSend))
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(messageToSend);
                    stream.Write(buffer, 0, buffer.Length);

                    messageToSend = Console.ReadLine();
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        Client client = new Client();
        Console.WriteLine("Inserisci l'IP del server:");
        string serverIP = Console.ReadLine();
        client.StartClient(serverIP, 3000);
    }
}