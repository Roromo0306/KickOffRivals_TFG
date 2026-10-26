using System;

namespace KickOffRivals.Domain.Models
{
    public sealed class MatchResult
    {
        public int HomeGoals { get; }
        public int AwayGoals { get; }

        public TeamSide? Winner => HomeGoals == AwayGoals ? (TeamSide?) null : (HomeGoals > AwayGoals ? TeamSide.Home : TeamSide.Away);

        public MatchResult(int homeGoals, int awayGoals)
        {
            if(homeGoals < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(homeGoals));
            }

            if (awayGoals < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(awayGoals));
            }

            HomeGoals = homeGoals;
            AwayGoals = awayGoals;
        }
    }
}