namespace RouterConfigurator.Interfaces
{
    public interface IEngine
    {
        void UpdateHostname(string property, string newName);
        public void InitializeConnection();
    }
}
