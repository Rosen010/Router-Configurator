namespace RouterConfigurator.Contracts
{
    public interface IEngine
    {
        void UpdateHostname(string property, string newName);
        public void InitializeConnection();
    }
}
