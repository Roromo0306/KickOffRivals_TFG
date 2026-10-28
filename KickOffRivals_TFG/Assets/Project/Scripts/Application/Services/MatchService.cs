
using System;
using System.Collections.Generic;
using KickOffRivals.Domain.Models;

namespace KickOffRivals.Application.Services
{
    public sealed class MatchService : IMatchService
    {
        private readonly MatchRules _rules;

        public MatchModel CurrentMatch { get; private set; }
        public MatchResult LastResult { get; private set; }

        public MatchService(MatchRules rules)
        {
            _rules = rules ??
                throw new ArgumentNullException(nameof(rules));
        }

        public void StartMatch()
        {
            if (CurrentMatch != null)
            {
                throw new InvalidOperationException(
                    "Ya hay una partida activa.");
            }

            var homePlayers = new List<PlayerModel>();
            var awayPlayers = new List<PlayerModel>();

            for (int i = 0; i < _rules.PlayersPerTeam; i++)
            {
                homePlayers.Add(
                    new PlayerModel(
                        i + 1,
                        TeamSide.Home));

                awayPlayers.Add(
                    new PlayerModel(
                        i + 1 + _rules.PlayersPerTeam,
                        TeamSide.Away));
            }

            var home = new TeamModel(
                TeamSide.Home,
                homePlayers,
                _rules.PlayersPerTeam);

            var away = new TeamModel(
                TeamSide.Away,
                awayPlayers,
                _rules.PlayersPerTeam);

            CurrentMatch = new MatchModel(
                home,
                away,
                new BallModel());

            LastResult = null;
        }

        public void FinishMatch()
        {
            if (CurrentMatch == null)
            {
                throw new InvalidOperationException(
                    "No hay una partida activa.");
            }

            LastResult = CurrentMatch.CreateResult();
            CurrentMatch = null;
        }
    }
}
