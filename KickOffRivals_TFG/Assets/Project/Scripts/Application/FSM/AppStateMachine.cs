using System;
using Unity.VisualScripting;

namespace KickOffRivals.Application.FSM
{
    public sealed class AppStateMachine
    {
        public AppState Current { get; private set; } = AppState.Boot;

        public event Action<AppState> StateChanged;

        public bool CanTransitionTo(AppState next)
        {
            switch (Current)
            {
                case AppState.Boot:
                    return next == AppState.Home;
                case AppState.Home:
                    return next == AppState.Loading;
                case AppState.Loading:
                    return next == AppState.Match || next == AppState.Home;
                default:
                    return false;
            }
        }

        public bool TryChangeState(AppState next)
        {
            if (!CanTransitionTo(next))
            {
                return false;
            }

            Current = next;
            StateChanged?.Invoke(next);

            return true;
        }
    }
}