﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace tttServer
{
    class GmServer
    {
        private IPAddress ipAdd = IPAddress.Parse("127.0.0.1");
        GameController gameController;
        private TcpClient pOne, pTwo;
        private TcpListener gServer;
        BinaryFormatter bf = new BinaryFormatter();
        Thread plOne, plTwo;
        public void ConnectOverIP()
        {

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
            gameController = new GameController();
            //plOne = new Thread(() => Communicate(pOne, pTwo, "0"));
            //plTwo = new Thread(() => Communicate(pTwo, pOne, "1"));
            //plOne.Start();
            //plTwo.Start();
            plOne = new Thread(() => ReciveAction(pOne, pTwo, "0", "1"));
            plTwo = new Thread(() => ReciveAction(pTwo, pOne, "1", "0"));
            plOne.Start();
            plTwo.Start();

        }

        public void ReciveAction(TcpClient player, TcpClient op, string playerNum, string opPlayer)
        {

            player = gServer.AcceptTcpClient();
            string msg = (string)bf.Deserialize(player.GetStream());
            Monitor.Enter(gameController);
            Console.WriteLine(msg);
            string[] data = msg.Split(':');
            string btnName = data[0];
            string grid = data[1] + ":" + data[2];
            gameController.GameProgressKeep(grid, playerNum);
            string serverMsg = $"{btnName}:{playerNum}:{GameController.winner}";
            Console.WriteLine("Server msg : " + serverMsg);
            SendAction(op, serverMsg);
            ReciveAction(op, player, opPlayer, playerNum);
            Monitor.Exit(gameController);
        }
        public void SendAction(TcpClient op, string msg)
        {


            op = gServer.AcceptTcpClient();

            Console.WriteLine(msg);
            bf.Serialize(op.GetStream(), msg);

        }

    }
}
