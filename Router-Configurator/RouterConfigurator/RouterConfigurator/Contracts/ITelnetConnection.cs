namespace RouterConfigurator.Contracts
{
    using System.Text;

    public interface ITelnetConnection
    {
        bool IsConnected { get; }

        public string Login(string Username, string Password, int LoginTimeOutMs);

        public void WriteLine(string cmd);

        public void Write(string cmd);

        public string Read();

        public void ParseTelnet(StringBuilder sb);
    }
}
