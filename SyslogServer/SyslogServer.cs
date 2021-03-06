﻿
namespace SyslogServer
{

    public enum NetworkProtocol
    {
        UPD,
        TCP,
        TLS
    } // End Enum NetworkProtocol 


    // TODO: create a composite-class for a general syslog server 
    class SyslogServer
    {

        protected TlsSyslogServer TlsServer;
        protected UpdSyslogServer UdpServer;
        protected TcpSyslogServer TcpServer;

        protected NetCoreServer.SslSession Session;
        protected SyslogTcpSession TcpSession;

        public int Port;


        public SyslogServer()
        {

        } // End Constructor 


        public void Start(NetworkProtocol protocol, System.Net.IPAddress address, int port)
        {
            switch (protocol)
            {
                case NetworkProtocol.TCP:
                    TcpSyslogServer.Test();
                    break;
                case NetworkProtocol.TLS:
                    TlsSyslogServer.Test();
                    break;
                default:
                    UpdSyslogServer.Test();
                    break;
            }

        } // End Sub Start 


        public void Start(NetworkProtocol protocol, System.Net.IPAddress address)
        {
            this.Port = 514; // UDP

            switch (protocol)
            {
                case NetworkProtocol.TCP:
                    this.Port = 1468; // TCP 
                    break;
                case NetworkProtocol.TLS:
                    this.Port = 6514; // TLS 
                    break;
            }

            Start(protocol, address, this.Port);
        } // End Sub Start  


        public void Stop()
        {

        } // End Sub Stop 


    } // End Class SyslogServer 


} // End Namespace SyslogServer 
