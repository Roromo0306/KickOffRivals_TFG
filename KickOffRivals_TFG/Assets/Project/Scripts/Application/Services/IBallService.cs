namespace KickOffRivals.Application.Services
{
    public interface IBallService
    {
        bool TryTakePossession(int playerId);
        void ReleaseBall();
    }
}