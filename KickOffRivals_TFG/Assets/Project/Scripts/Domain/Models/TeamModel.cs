using System;
using System.Collections.Generic;

namespace KickOffRivals.Domain.Models
{
    public sealed class TeamModel
    {
        public TeamSide Side { get; }
        public IReadOnlyList<PlayerModel> Players { get; }

        public TeamModel(TeamSide side, IEnumerable<PlayerModel> players, int expectedCount)
        {
            if (!Enum.IsDefined(typeof(TeamSide), side))
            {
                throw new ArgumentOutOfRangeException(nameof(side));
            }

            if (players == null)
            {
                throw new ArgumentNullException(nameof(players));
            }

            if (expectedCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(expectedCount));
            }

            var copy = new List<PlayerModel>(players);

            if (copy.Count != expectedCount)
            {
                throw new ArgumentException("La cantidad de jugadores no coincide", nameof(players));
            }

            var ids = new HashSet<int>();

            foreach (var player in copy)
            {
                if (player == null || player.Side != side || !ids.Add(player.Id))
                {
                    throw new ArgumentException("Jugador nulo, equipo incorreto o ID Repetido", nameof(players));
                }
            }

            side = Side;
            Players = copy.AsReadOnly();
        }
    }
}