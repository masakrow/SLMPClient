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
        SLMPFrame Frame = new SLMPFrame();

        private static readonly int CONNECTION_OK = 1;
        private static readonly int CONNECTION_NG = -1;

        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }

        public int connect(string address, int port)
        {
            if(socket != null)
            {
                return CONNECTION_NG;
            }

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    socket.Connect(new IPEndPoint(IPAddress.Parse(address), 11000));
                    Debug.WriteLine("Connection Opened with {0}", socket.RemoteEndPoint.ToString());
                    return CONNECTION_OK;
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
            return CONNECTION_NG;
        }
        public int send(byte [] pucStream)
        {
            if (socket == null)
            {
                return CONNECTION_NG;
            }
            try
            {
                int bytesSend = socket.Send(pucStream);
                Debug.WriteLine("Packeg Send, No Bytes {0}", bytesSend);

                return CONNECTION_OK;
            } catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            return CONNECTION_NG;
        }
    }
}
