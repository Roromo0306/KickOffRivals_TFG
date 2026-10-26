using System;

namespace KickOffRivals.Domain.Models
{
    public sealed class MatchRules
    {
        public int PlayersPerTeam { get; }
        public float DurationSeconds { get;}

        public MatchRules(int playersPerTeam, float durationSeconds)
        {
            if(playersPerTeam != 3)
            {
                throw new ArgumentOutOfRangeException(nameof(playersPerTeam), "Se necesitan 3 jugadores");
            }

            if(float.IsNaN(durationSeconds) || float.IsInfinity(durationSeconds) || durationSeconds <= 0f)
            {
                throw new ArgumentOutOfRangeException(nameof(durationSeconds));
            }

            PlayersPerTeam = playersPerTeam;
            DurationSeconds = durationSeconds;
        }
    }
}