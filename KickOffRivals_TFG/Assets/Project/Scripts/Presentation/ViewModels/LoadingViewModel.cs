using System;
using KickOffRivals.Application.Services;

namespace KickOffRivals.Presentation.ViewModels
{
    public sealed class LoadingViewModel
    {
        private readonly INavigationService _navigation;

        public string Message => "Preparando partido 3v3";

        public LoadingViewModel(INavigationService navigation)
        {
            _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation)); 
        }

        public void Continue()
        {
            _navigation.EnterMatch();
        }
    }
}