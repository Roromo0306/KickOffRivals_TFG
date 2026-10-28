using System;
using KickOffRivals.Application.Services;

namespace KickOffRivals.Presentation.ViewModels
{
    public sealed class ResultViewModel
    {
        private readonly INavigationService _navigation;
        
        public string Summary { get; }

        public ResultViewModel(IMatchService matchService, INavigationService navigation)
        {
            if(matchService == null)
            {
                throw new ArgumentNullException(nameof(matchService));
            }

            _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));

            var result = matchService.LastResult;

            Summary = result == null ? "No hay resultados" : $"Resultado provisional{result.HomeGoals} - {result.AwayGoals}";
        }

        public void BackToHome()
        {
            _navigation.GoHome();
        }
    }
}