using System;

namespace KickOffRivals.Domain.Models
{
    public enum TeamSide
    {
        Home,
        Away
    }

    public sealed class PlayerModel
    {
        public int Id { get; }
        public TeamSide Side { get; }

        public PlayerModel(int id, TeamSide side)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            Id = id;
            Side = side;
        }
    }
}