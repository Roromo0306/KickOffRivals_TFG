
using NUnit.Framework;
using KickOffRivals.Application.Services;
using KickOffRivals.Domain.Models;

namespace KickOffRivals.Tests.EditMode
{
    public sealed class MatchAndBallServiceTests
    {
        [Test]
        public void StartMatch_CreatesSixPlayersAndFreeBall()
        {
            var service = new MatchService(new MatchRules(3, 180f));

            service.StartMatch();

            Assert.AreEqual(3, service.CurrentMatch.Home.Players.Count);

            Assert.AreEqual(3, service.CurrentMatch.Away.Players.Count);

            Assert.IsTrue(service.CurrentMatch.Ball.IsFree);
        }

        [Test]
        public void Ball_CannotBelongToTwoPlayersSimultaneously()
        {
            var match = new MatchService(new MatchRules(3, 180f));

            match.StartMatch();

            var ball = new BallService(match);

            Assert.IsTrue(ball.TryTakePossession(1));

            Assert.IsFalse(ball.TryTakePossession(4));

            Assert.AreEqual(1, match.CurrentMatch.Ball.OwnerPlayerId);
        }

        [Test]
        public void FinishMatch_StoresResultAndReleasesActiveMatch()
        {
            var match = new MatchService(new MatchRules(3, 180f));

            match.StartMatch();
            match.FinishMatch();

            Assert.IsNull(match.CurrentMatch);
            Assert.IsNotNull(match.LastResult);

            Assert.AreEqual(0, match.LastResult.HomeGoals);
        }
    }
}
