using System;

namespace tttServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GmServer gm = new GmServer();
            gm.ConnectOverIP();
        }
    }
}
