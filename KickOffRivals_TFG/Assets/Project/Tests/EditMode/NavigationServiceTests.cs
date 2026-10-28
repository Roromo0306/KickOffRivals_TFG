
using System.Collections.Generic;
using NUnit.Framework;
using KickOffRivals.Application.FSM;
using KickOffRivals.Application.Ports;
using KickOffRivals.Application.Services;
using KickOffRivals.Domain.Models;

namespace KickOffRivals.Tests.EditMode
{
    public sealed class NavigationServiceTests
    {
        private sealed class FakeSceneLoader : ISceneLoader
        {
            public readonly List<string> Loaded =new List<string>();

            public void Load(string sceneName)
            {
                Loaded.Add(sceneName);
            }
        }

        [Test]
        public void Navigation_CompletesFlowWithoutGameObjects()
        {
            var match = new MatchService(new MatchRules(3, 180f));

            var loader = new FakeSceneLoader();

            var nav = new NavigationService(new AppStateMachine(),loader,match);

            Assert.IsTrue(nav.GoHome());
            Assert.IsTrue(nav.OpenLoading());
            Assert.IsTrue(nav.EnterMatch());

            Assert.IsNotNull(match.CurrentMatch);

            Assert.IsTrue(nav.ShowResults());
            Assert.IsNotNull(match.LastResult);

            Assert.IsTrue(nav.GoHome());

            CollectionAssert.AreEqual(
                new[]
                {
                    "Home",
                    "Loading",
                    "Match",
                    "Results",
                    "Home"
                },
                loader.Loaded);
        }

        [Test]
        public void InvalidNavigation_DoesNotLoadOrCreateMatch()
        {
            var match = new MatchService(new MatchRules(3, 180f));

            var loader = new FakeSceneLoader();

            var nav = new NavigationService(new AppStateMachine(),loader,match);

            Assert.IsFalse(nav.EnterMatch());
            Assert.IsNull(match.CurrentMatch);
            Assert.IsEmpty(loader.Loaded);
        }
    }
}
