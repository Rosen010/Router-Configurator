namespace RouterConfigurator.Reader
{
    using System.IO;
    using System.Text;

    using RouterConfigurator.Contracts;

    public class FileReader : IReader
    {
        public string Read(string file)
        {
            string text = File.ReadAllText(file);
            return text;
        }    
    }
}
