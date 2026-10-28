using KickOffRivals.Domain.Models;

namespace KickOffRivals.Application.Services
{
    public interface IMatchService
    {
        MatchModel CurrentMatch {  get; }
        MatchModel LastResult { get; }

        void StartMatch();
        void FinishMatch();
    }
}