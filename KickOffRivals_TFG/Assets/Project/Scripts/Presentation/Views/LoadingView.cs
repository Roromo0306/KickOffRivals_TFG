using TMPro;
using UnityEngine;
using UnityEngine.UI;
using KickOffRivals.Presentation.ViewModels;

namespace KickOffRivals.Presentation.Views
{
    public sealed class LoadingView : MonoBehaviour
    {
        [SerializeField] private TMP_Text messageText;
        [SerializeField] private Button continueButton;

        private LoadingViewModel _viewModel;

        public void Bind(LoadingViewModel viewModel)
        {
            Unbind();

            _viewModel = viewModel;
            messageText.text = _viewModel.Message;

            continueButton.onClick.AddListener(OnContinueClicked);

        }

        private void OnContinueClicked()
        {
            _viewModel?.Continue();
        }

        public void Unbind()
        {
            if(continueButton != null)
            {
                continueButton.onClick.RemoveListener(OnContinueClicked);
            }

            _viewModel = null;
        }

        private void OnDestroy()
        {
            Unbind();
        }
    }
}