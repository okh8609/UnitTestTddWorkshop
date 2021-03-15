namespace OnlineStoreBackend
{
    public interface IPersistenceManager
    {
        bool CheckUsernameExists(string username);
    }
}