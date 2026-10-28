
using System;
using KickOffRivals.Application.FSM;
using KickOffRivals.Application.Ports;

namespace KickOffRivals.Application.Services
{
    public sealed class NavigationService : INavigationService
    {
        private readonly AppStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IMatchService _matchService;

        public AppState State => _stateMachine.Current;

        public NavigationService(AppStateMachine stateMachine, ISceneLoader sceneLoader, IMatchService matchService)
        {
            _stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));

            _sceneLoader = sceneLoader ?? throw new ArgumentNullException(nameof(sceneLoader));

            _matchService = matchService ?? throw new ArgumentNullException(nameof(matchService));
        }

        public bool GoHome()
        {
            return TransitionAndLoad(AppState.Home, "Home");
        }

        public bool OpenLoading()
        {
            return TransitionAndLoad(AppState.Loading, "Loading");
        }

        public bool EnterMatch()
        {
            if (!_stateMachine.CanTransitionTo(AppState.Match))
            {
                return false;
            }
              

            _matchService.StartMatch();

            return TransitionAndLoad(AppState.Match, "Match");
        }

        public bool ShowResults()
        {
            if (!_stateMachine.CanTransitionTo(AppState.Results))
            {
                return false;
            }
               

            _matchService.FinishMatch();

            return TransitionAndLoad(AppState.Results, "Results");
        }

        private bool TransitionAndLoad(AppState next, string sceneName)
        {
            if (!_stateMachine.TryChangeState(next))
            {
                return false;
            }

            _sceneLoader.Load(sceneName);

            return true;
        }
    }
}
