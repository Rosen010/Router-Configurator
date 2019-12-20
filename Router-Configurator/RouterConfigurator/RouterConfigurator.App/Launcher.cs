namespace RouterConfigurator.App
{
    using System.Diagnostics;

    class Launcher
    {
        static void Main(string[] args)
        {       
            ProcessStartInfo processInfo = new ProcessStartInfo(Configuration.processDirectory);
            Process process = new Process();

            process.StartInfo = processInfo;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;

            CommandInterpreter commandInterpreter = new CommandInterpreter(process);
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
