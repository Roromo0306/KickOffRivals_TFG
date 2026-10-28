using System;
using KickOffRivals.Application.Services;

namespace KickOffRivals.Presentation.ViewModels
{
    public sealed class MatchHudViewModel
    {
        private readonly IMatchService _matchService;
        private readonly INavigationService _navigation;

        public string ScoreText
        {
            get
            {
                var match = _matchService.CurrentMatch;

                return match == null ? "- - -" : $"{match.HomeGoals} - {match.AwayGoals}";
            }
        }

        public MatchHudViewModel(IMatchService matchService, INavigationService navigation)
        {
            _matchService = matchService ?? throw new ArgumentNullException(nameof(matchService));
            _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
        }

        public void FinishMatch()
        {
            _navigation.ShowResults();
        }
    }
}