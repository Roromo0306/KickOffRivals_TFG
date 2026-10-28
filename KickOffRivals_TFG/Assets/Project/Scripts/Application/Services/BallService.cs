using System;

namespace KickOffRivals.Application.Services
{
    public sealed class BallService : IBallService
    {
        private readonly IMatchService _matchService;

        public BallService(IMatchService matchService)
        {
            _matchService = matchService ?? throw new ArgumentNullException(nameof(matchService));
        }

        public bool TryTakePossession(int playerId)
        {
            var match = _matchService.CurrentMatch;

            if(match == null || !match.ContainsPlayer(playerId) || !match.Ball.IsFree)
            {
                return false;
            }

            match.Ball.AssignOwner(playerId);

            return true;
        }

        public void ReleaseBall()
        {
            var match = _matchService.CurrentMatch;

            if(match != null)
            {
                match.Ball.Release();
            }
        }
    }
}