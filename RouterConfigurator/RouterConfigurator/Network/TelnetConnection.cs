// minimalistic telnet implementation
// conceived by Tom Janssens on 2007/06/06  for codeproject
//
// http://www.corebvba.be

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using RouterConfigurator.Contracts;

namespace RouterConfigurator.Network
{
    enum Verbs
    {
        WILL = 251,
        WONT = 252,
        DO = 253,
        DONT = 254,
        IAC = 255
    }

    enum Options
    {
        SGA = 3
    }

    class TelnetConnection : ITelnetConnection
    {
        TcpClient tcpSocket;

        private int timeOutMs = 100;

        public TelnetConnection(string ipAddress, int port)
        {
            tcpSocket = new TcpClient();
            IPAddress address = IPAddress.Parse(ipAddress);
            tcpSocket.Connect(address, port);

        }

        public string Login(string Username, string Password, int LoginTimeOutMs)
        {
            int oldTimeOutMs = this.timeOutMs;
            this.timeOutMs = LoginTimeOutMs;
            string s = Read();

            if (!s.TrimEnd().EndsWith(":"))
            {
                throw new Exception("Failed to connect : no login prompt");
            }

            WriteLine(Username);
            s += Read();

            if (!s.TrimEnd().EndsWith(":"))
            {
                throw new Exception("Failed to connect : no password prompt");
            }

            WriteLine(Password);

            s += Read();
            this.timeOutMs = oldTimeOutMs;
            return s;
        }

        public void WriteLine(string cmd)
        {
            Write(cmd + Environment.NewLine); // it was with \n before
        }

        public void Write(string cmd)
        {
            if (!tcpSocket.Connected)
            {
                return;
            }

            byte[] buf = System.Text.ASCIIEncoding.ASCII.GetBytes(cmd.Replace("\0xFF", "\0xFF\0xFF"));
            tcpSocket.GetStream().Write(buf, 0, buf.Length);
        }

        public string Read()
        {
            if (!tcpSocket.Connected)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();

            do
            {
                ParseTelnet(sb);
                System.Threading.Thread.Sleep(timeOutMs);
            } while (tcpSocket.Available > 0);

            return sb.ToString();
        }

        public bool IsConnected
        {
            get { return tcpSocket.Connected; }
        }

        public void ParseTelnet(StringBuilder sb)
        {
            while (tcpSocket.Available > 0)
            {
                int input = tcpSocket.GetStream().ReadByte();
                switch (input)
                {
                    case -1:
                        break;
                    case (int)Verbs.IAC:
                        // interpret as command
                        int inputverb = tcpSocket.GetStream().ReadByte();

                        if (inputverb == -1)
                        {
                            break;
                        }

                        switch (inputverb)
                        {
                            case (int)Verbs.IAC:
                                //literal IAC = 255 escaped, so append char 255 to string
                                sb.Append(inputverb);
                                break;
                            case (int)Verbs.DO:
                            case (int)Verbs.DONT:
                            case (int)Verbs.WILL:
                            case (int)Verbs.WONT:
                                // reply to all commands with "WONT", unless it is SGA (suppres go ahead)

                                int inputoption = tcpSocket.GetStream().ReadByte();
                                if (inputoption == -1)
                                {
                                    break;
                                }

                                tcpSocket.GetStream().WriteByte((byte)Verbs.IAC);

                                if (inputoption == (int)Options.SGA)
                                {
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WILL : (byte)Verbs.DO);
                                }

                                else
                                {
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WONT : (byte)Verbs.DONT);
                                }

                                tcpSocket.GetStream().WriteByte((byte)inputoption);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        sb.Append((char)input);
                        break;
                }
            }
        }
    }
}
