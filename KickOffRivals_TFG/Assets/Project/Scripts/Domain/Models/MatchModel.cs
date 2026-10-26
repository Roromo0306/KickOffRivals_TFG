using System;
using System.Collections.Generic;

namespace KickOffRivals.Domain.Models
{
    public sealed class MatchModel
    {
        public TeamModel Home { get; }
        public TeamModel Away { get; }
        public BallModel Ball { get; }

        public int HomeGoals { get; private set; }
        public int AwayGoals { get; private set; }

        public MatchModel(TeamModel home, TeamModel away, BallModel ball)
        {
            Home = home ?? throw new ArgumentNullException(nameof(home));
            Away = away ?? throw new ArgumentNullException(nameof(away));
            Ball = ball ?? throw new ArgumentNullException(nameof(ball));   

            if(home.Side != TeamSide.Home || away.Side != TeamSide.Away)
            {
                throw new ArgumentException("Los equipos están asignados en el lado incorrecto");
            }

            var ids = new HashSet<int>();

            foreach(var player in home.Players)
            {
                ids.Add(player.Id);
            }

            foreach(var player in away.Players)
            {
                if (!ids.Add(player.Id))
                {
                    throw new ArgumentException("Hay IDs de jugadores repetidos entre los equipos");
                }
            }
        }

        public bool ContainsPlayer(int playerId)
        {
            foreach(var player in Home.Players)
            {
                if(player.Id == playerId)
                {
                    return true;
                }             
            }

            foreach (var player in Away.Players)
            {
                if (player.Id == playerId)
                {
                    return true;
                }
            }

            return false;
        }

        public MatchResult CreateResult()
        {
            return new MatchResult(HomeGoals, AwayGoals);
        }
    }
}