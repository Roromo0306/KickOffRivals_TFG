using System;

namespace KickOffRivals.Domain.Models
{
    public sealed class BallModel
    {
        public int? OwnerPlayerId { get; set; }
        public bool IsFree => !OwnerPlayerId.HasValue;

        public void AssignOwner(int playerId)
        {
            if (playerId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playerId));
            }

            OwnerPlayerId = playerId;
        }

        public void Release()
        {
            OwnerPlayerId = null;
        }
    }
}