using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

namespace SLMPClient
{

  
    class Connection
    {
        private Socket socket;
        private const int bufSize = 255;
        private State state = new State();

        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }

        public bool connect(string address, int port)
        {
            if(socket != null)
            {
                return false;
            }

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    socket.Connect(new IPEndPoint(IPAddress.Parse(address), 11000));
                    Debug.WriteLine("Connection Opened with {0}", socket.RemoteEndPoint.ToString());
                    return true;
                }
                catch (SocketException se)
                {
                    Debug.WriteLine(se.ToString());
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            return false;
        }
    }
}
