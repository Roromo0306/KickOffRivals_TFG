using UnityEngine;
using KickOffRivals.Presentation.ViewModels;
using KickOffRivals.Presentation.Views;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private HomeView homeView;

    private void Awake()
    {
        if(homeView == null)
        {
            Debug.LogError("HomeView no asignada.");
            return;
        }

        var homeViewModel = new HomeViewModel();
        homeView.Bind(homeViewModel);

        Debug.Log("Kick Off Rivals inicializado");

    }
}
