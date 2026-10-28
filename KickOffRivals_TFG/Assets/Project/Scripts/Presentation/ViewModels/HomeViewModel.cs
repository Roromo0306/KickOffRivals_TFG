using System;
using KickOffRivals.Application.Services;

namespace KickOffRivals.Presentation.ViewModels
{
    public sealed class HomeViewModel
    {
        private readonly INavigationService _navigation;

        public string Title => "KICK OFF RIVALS";
        public string Status => "Prototipo w2 - Menu de prueba";

        public HomeViewModel(INavigationService navigation)
        {
            _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
        }

        public void Play()
        {
            _navigation.OpenLoading();
        }

    }
}