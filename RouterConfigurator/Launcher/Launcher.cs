using System;
using System.Diagnostics;
using System.Threading;

namespace Launcher
{
    class Launcher
    {
        static void Main(string[] args)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo(@"C:\Users\roska\Desktop\Coding\Semester Project\Router-Configurator\RouterConfigurator\RouterConfigurator\bin\Debug\netcoreapp3.0/RouterConfigurator");

            Process process = new Process();
            process.StartInfo = processInfo;

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;

            process.Start();

            Thread.Sleep(3000);

            process.StandardInput.WriteLine("en");
            Thread.Sleep(1000);
            process.StandardInput.WriteLine("cisco");
            Thread.Sleep(1000);
            process.StandardInput.WriteLine("conf t");
            Thread.Sleep(1000);
            process.StandardInput.WriteLine("hostname Pesho");
            Thread.Sleep(1000);
            process.StandardInput.WriteLine("exit");

        }
    }
}
