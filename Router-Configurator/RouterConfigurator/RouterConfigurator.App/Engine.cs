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
            Console.WriteLine("To change Ip Address press: 2");
            Console.WriteLine("To view router info press: 3");
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
                else if (command == 2)
                {
                    try
                    {
                        Console.Write("Please enter new Interface: ");
                        string newInterface = Console.ReadLine();
                        Console.Write("Please enter new Subnet Mask: ");
                        string newIpAddress = Console.ReadLine();
                        Console.Write("Please enter new Ip Addrress: ");
                        string newSubnetMask = Console.ReadLine();

                        commandInterpreter.ChangeInterfaceIpAddressAndSubnetMask(newInterface, newIpAddress, newSubnetMask);
                        Console.WriteLine($"Succesfully changed Interface {newInterface}, Ip Address {newIpAddress} and Subnet Mask {newSubnetMask}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (command == 3)
                {
                    Console.WriteLine("Showing router info: ");

                    commandInterpreter.ShowRouterInfo();
                }

                Console.Write("Choose another operation or exit: ");
                command = int.Parse(Console.ReadLine());
            }
        }
    }
}
