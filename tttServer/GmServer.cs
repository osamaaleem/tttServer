using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace tttServer
{
    class GmServer
    {
        private IPAddress ipAdd = IPAddress.Parse("127.0.0.1");
        private TcpClient pOne, pTwo;
        private TcpListener gServer;
        public void Connect()
        {
            BinaryFormatter bf = new BinaryFormatter();
            gServer = new TcpListener(ipAdd, 9267);
            gServer.Start();
            pOne = gServer.AcceptTcpClient();
            Console.WriteLine($"Connected to {pOne.Client.RemoteEndPoint}");
            bf.Serialize(pOne.GetStream(), "1");
            string name = (string)bf.Deserialize(pOne.GetStream());
            Console.WriteLine($"Player One Username : {name}");
            pTwo = gServer.AcceptTcpClient();
            Console.WriteLine($"Connected to {pTwo.Client.RemoteEndPoint}");
            bf.Serialize(pTwo.GetStream(), "2");
            name = (string)bf.Deserialize(pTwo.GetStream());
            Console.WriteLine($"Player Two Username : {name}");

        }
      
    }
}
