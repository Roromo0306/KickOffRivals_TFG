using UnityEngine;
using KickOffRivals.Application.Services;
using KickOffRivals.Presentation.ViewModels;
using KickOffRivals.Presentation.Views;

namespace KickOffRivals.Composition
{
    public sealed class SceneCompositionRoot : MonoBehaviour
    {
        [SerializeField] private HomeView homeView;
        [SerializeField] private LoadingView loadingView;
        [SerializeField] private MatchHudView matchHudView;
        [SerializeField] private ResultsView resultsView;

        private bool _initialized;

        public void Initialize(INavigationService navigation, IMatchService matchService)
        {
            if (_initialized)
            {
                return;
            }

            int viewCount = (homeView != null ? 1 : 0) + (loadingView != null ? 1 : 0) + (matchHudView != null ? 1 : 0) + (resultsView != null ? 1 : 0);

            if(viewCount != 1)
            {
                Debug.LogError("Cada SceneCompositionRoot debe tener exactamente una View asignada");
                return;
            }

            if(homeView != null)
            {
                homeView.Bind(new HomeViewModel(navigation));
            }

            if (loadingView != null)
            {
                loadingView.Bind(new LoadingViewModel(navigation));
            }

            if (matchHudView != null)
            {
                matchHudView.Bind(new MatchHudViewModel(matchService, navigation));
            }

            if (resultsView != null)
            {
                resultsView.Bind(new ResultViewModel(matchService, navigation));
            }

            _initialized = true;
        }
    }
}