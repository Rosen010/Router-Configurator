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
            this.process.Start();

            Thread.Sleep(2000);
            this.process.StandardInput.WriteLine("en");
            Thread.Sleep(1000);
            this.process.StandardInput.WriteLine("cisco");
            Thread.Sleep(1000);
            this.process.StandardInput.WriteLine("conf t");
            Thread.Sleep(1000);
            this.process.StandardInput.WriteLine($"hostname {newName}");
            Thread.Sleep(1000);
            this.process.StandardInput.WriteLine("exit");
        }
    }
}
