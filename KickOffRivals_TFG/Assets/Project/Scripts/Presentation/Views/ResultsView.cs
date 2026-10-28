using TMPro;
using UnityEngine;
using UnityEngine.UI;
using KickOffRivals.Presentation.ViewModels;

namespace KickOffRivals.Presentation.Views
{
    public sealed class ResultsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text resultText;
        [SerializeField] private Button homeButton;

        private ResultViewModel _viewModel;

        public void Bind(ResultViewModel viewModel)
        {
            Unbind();

            _viewModel = viewModel;
            resultText.text = _viewModel.Summary;

            homeButton.onClick.AddListener(OnContinueClicked);

        }

        private void OnContinueClicked()
        {
            _viewModel?.BackToHome();
        }

        public void Unbind()
        {
            if (homeButton != null)
            {
                homeButton.onClick.RemoveListener(OnContinueClicked);
            }

            _viewModel = null;
        }

        private void OnDestroy()
        {
            Unbind();
        }
    }
}