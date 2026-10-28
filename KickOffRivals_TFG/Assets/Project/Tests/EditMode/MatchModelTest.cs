using System;
using NUnit.Framework;
using KickOffRivals.Domain.Models;

namespace KickOffRivals.Tests.EditMode
{
    public sealed class MatchModelTests
    {
        [Test]
        public void MatchResult_DrawHasNoWinner()
        {
            var result = new MatchResult(0, 0);

            Assert.IsFalse(result.Winner.HasValue);
        }

        [Test]
        public void MatchResult_HomeWinReturnsHome()
        {
            var result = new MatchResult(2, 1);

            Assert.AreEqual(TeamSide.Home, result.Winner);
        }

        [Test]
        public void MatchResult_RejectsNegativeScore()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MatchResult(-1, 0));
        }
    }
}
