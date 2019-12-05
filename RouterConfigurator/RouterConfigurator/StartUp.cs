namespace RouterConfigurator
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    using RouterConfigurator.UI;
    using RouterConfigurator.Reader;
    using RouterConfigurator.Writer;
    using RouterConfigurator.Interfaces;
    using MinimalisticTelnet;

    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new FileReader();
            IWriter writer = new FileWriter();
            IEngine engine = new Engine(writer, reader);
            ICommandProcessor processor = new CommandProcessor(engine);

            //processor.GetInput();

            engine.InitializeConnection();
        }
    }
}
