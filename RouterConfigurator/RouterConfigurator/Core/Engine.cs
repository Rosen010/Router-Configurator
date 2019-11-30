namespace RouterConfigurator
{
    using RouterConfigurator.Interfaces;
    using RouterConfigurator.Reader;
    using RouterConfigurator.Writer;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private string fileText;

        public Engine(IWriter writer, IReader reader)
        {
            this.reader = reader;
            this.writer = writer;

            this.ReadFileText();
        }

        public void UpdateHostname(string property, string newName)
        {
            //finding property
            var hostnamePropIndex = fileText.IndexOf(property);

            // getting the whole property row
            var hostnameProp = fileText.Substring(hostnamePropIndex, 20);

            // getting the actual value
            var hostnamePropValue = hostnameProp.Substring(9, hostnameProp.IndexOf('\n') - 9);

            // updating the value
            this.fileText = fileText.Replace(hostnamePropValue, newName);

            writer.Write(this.fileText, Configuration.outputFilePath);
        }

        private void ReadFileText()
        {
            this.fileText = this.reader.Read(Configuration.inputFilePath);
        }
    }
}
