namespace RouterConfigurator.UI
{
    using RouterConfigurator.Interfaces;
    using System;

    //the class is a bit leshta
    public class CommandProcessor : ICommandProcessor
    {
        private IEngine engine;
        private string property;

        public CommandProcessor(IEngine engine)
        {
            this.engine = engine;
        }

        public void GetInput()
        {
            Console.Write("Enter the property, you wish to change: ");
            this.property = Console.ReadLine();
            
            if (this.property == "hostname")
            {
                Console.Write("Enter new name: ");
                var newName = Console.ReadLine();

                engine.UpdateHostname(this.property, newName);
            }
        }

        public void ProcessInput()
        {
            // Not sure how logic will flow in this class.
        }
    }
}
