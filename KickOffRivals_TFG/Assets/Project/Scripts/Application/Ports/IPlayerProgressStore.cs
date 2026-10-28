namespace KickOffRivals.Application.Ports
{
    public interface IPlayerProgressStore
    {
        string LoadJson();
        void SaveJson(string json); 
    }
}