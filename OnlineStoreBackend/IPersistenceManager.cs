namespace OnlineStoreBackend
{
    public interface IPersistenceManager
    {
        bool CheckUsernameExists(string username);
        void SaveAccount(string username, string password);
        bool VerifyAccount(string username, string password);
    }
}