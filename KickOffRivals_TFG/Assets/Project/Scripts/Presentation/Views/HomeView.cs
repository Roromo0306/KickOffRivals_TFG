using TMPro;
using UnityEngine;
using KickOffRivals.Presentation.ViewModels;

namespace KickOffRivals.Presentation.Views
{
    public sealed class HomeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text statusText;

        public void Bind(HomeViewModel viewModel)
        {
            titleText.text = viewModel.Title;
            statusText.text = viewModel.Status;
        }
    }
}