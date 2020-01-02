namespace RouterConfigurator.App
{
    using System.Diagnostics;
    using System.Threading;

    public class CommandInterpreter
    {
        private Process process;

        public CommandInterpreter(Process process)
        {
            this.process = process;
        }
       
        public void ChangeHostname(string newName)
        {
            ConnectionCommand();
            Thread.Sleep(1000);
            this.process.StandardInput.WriteLine($"hostname {newName}");
            Thread.Sleep(1000);
            this.process.StandardInput.WriteLine("exit");
        }

       
        public void ChangeInterfaceIpAddressAndSubnetMask (string newInterface, string newIpAddress, string newSubnetMask)
        {
            ConnectionCommand();

            this.process.StandardInput.WriteLine($"interface {newInterface}");
            Thread.Sleep(1000);
            this.process.StandardInput.WriteLine($"ip address {newIpAddress} {newSubnetMask}");
            Thread.Sleep(1000);
            this.process.StandardInput.WriteLine("no shutdown");
            Thread.Sleep(1000);
            this.process.StandardInput.WriteLine("exit");

        }
        public void ShowRouterInfo()
        {
            ConnectionCommand();

            this.process.StandardInput.WriteLine("show run");
            Thread.Sleep(7000);
            this.process.StandardInput.WriteLine("exit");

        }
        private void ConnectionCommand()
        {
            this.process.Start();

            Thread.Sleep(2000);
            this.process.StandardInput.WriteLine("en");
            Thread.Sleep(1000);
            this.process.StandardInput.WriteLine("cisco");
            Thread.Sleep(1000);
            this.process.StandardInput.WriteLine("conf t");
            Thread.Sleep(1000);
        }

    }
}
