using KickOffRivals.Application.FSM;

namespace KickOffRivals.Application.Services
{
    public interface INavigationService
    {
        AppState State { get; }

        bool GoHome();
        bool OpenLoading();
        bool EnterMatch();
        bool ShowResults();

    }
}