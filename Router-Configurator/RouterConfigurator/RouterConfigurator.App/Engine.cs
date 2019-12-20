namespace RouterConfigurator.App
{
    using System;

    public class Engine
    {
        private CommandInterpreter commandInterpreter;

        public Engine(CommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            Console.WriteLine("Choose an operation to perform: ");
            Console.WriteLine("To change hostname press: 1");
            Console.WriteLine("To exit press: 0");

            int command = int.Parse(Console.ReadLine());

            while (command != 0)
            {
                if (command == 1)
                {
                    try
                    {
                        Console.Write("Choose new hostname: ");
                        string hostname = Console.ReadLine();
                        commandInterpreter.ChangeHostname(hostname);
                        Console.WriteLine($"Succesfully changed hostname to {hostname}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                Console.Write("Choose another operation or exit: ");
                command = int.Parse(Console.ReadLine());
            }
        }
    }
}
