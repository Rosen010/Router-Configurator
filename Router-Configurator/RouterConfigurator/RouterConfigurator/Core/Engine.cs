namespace RouterConfigurator
{
    using RouterConfigurator.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ITelnetConnection tc;
        private string fileText;

        public Engine(IWriter writer, IReader reader, ITelnetConnection tc)
        {
            this.reader = reader;
            this.writer = writer;
            this.tc = tc;

            this.ReadFileText();
        }
        
        public void InitializeConnection()
        {
            string s = tc.Login("root", "cisco", 100);
            Console.WriteLine(s);

            string prompt = s.TrimEnd();
            prompt = s.Substring(prompt.Length - 1, 1);

            if (prompt != "$" && prompt != ">")
            {
                throw new Exception("Connection failed");
            }

            prompt = "";

            // while connected
            while (tc.IsConnected && prompt.Trim() != "exit")
            {
                // display server output
                Console.Write(tc.Read());

                // send client input to server
                prompt = Console.ReadLine();
                tc.WriteLine(prompt);

                // display server output
                Console.Write(tc.Read());
            }

            Console.WriteLine("***DISCONNECTED");
            Console.ReadLine();
        }

        private void ReadFileText()
        {
            this.fileText = this.reader.Read(Configuration.inputFilePath);
        }
    }
}
