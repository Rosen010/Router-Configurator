namespace RouterConfigurator
{
    using RouterConfigurator.UI;
    using RouterConfigurator.Reader;
    using RouterConfigurator.Writer;
    using RouterConfigurator.Contracts;
    using RouterConfigurator.Network;

    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new FileReader();
            IWriter writer = new FileWriter();
            ITelnetConnection connection = new TelnetConnection(Configuration.IpAddress, Configuration.Port);
            IEngine engine = new Engine(writer, reader, connection);
            ICommandProcessor processor = new CommandProcessor(engine);
            
            engine.InitializeConnection();

            //processor.GetInput();
        }
    }
}
