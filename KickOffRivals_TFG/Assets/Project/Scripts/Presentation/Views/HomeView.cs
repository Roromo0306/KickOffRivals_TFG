using TMPro;
using UnityEngine;
using UnityEngine.UI;
using KickOffRivals.Presentation.ViewModels;

namespace KickOffRivals.Presentation.Views
{
    public sealed class HomeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text statusText;
        [SerializeField] private Button playButton;

        private HomeViewModel _viewModel;

        public void Bind(HomeViewModel viewModel)
        {
            Unbind();

            _viewModel = viewModel;

            titleText.text = viewModel.Title;
            statusText.text = viewModel.Status;

            playButton.onClick.AddListener(OnPlayClicked);
        }

        private void OnPlayClicked()
        {
            _viewModel?.Play();
        }

        public void Unbind()
        {
            if(playButton != null)
            {
                playButton.onClick.RemoveListener(OnPlayClicked);
            }

            _viewModel = null;
        }

        private void OnDestroy()
        {
            Unbind();
        }
    }
}