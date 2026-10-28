
using NUnit.Framework;
using KickOffRivals.Application.FSM;

namespace KickOffRivals.Tests.EditMode
{
    public sealed class AppStateMachineTests
    {
        [Test]
        public void ValidFlow_CompletesAndReturnsHome()
        {
            var machine = new AppStateMachine();

            Assert.IsTrue(machine.TryChangeState(AppState.Home));

            Assert.IsTrue(machine.TryChangeState(AppState.Loading));

            Assert.IsTrue(machine.TryChangeState(AppState.Match));

            Assert.IsTrue(machine.TryChangeState(AppState.Results));

            Assert.IsTrue(machine.TryChangeState(AppState.Home));
        }

        [Test]
        public void BootCannotSkipDirectlyToMatch()
        {
            var machine = new AppStateMachine();

            Assert.IsFalse(machine.TryChangeState(AppState.Match));

            Assert.AreEqual(AppState.Boot, machine.Current);
        }
    }
}
