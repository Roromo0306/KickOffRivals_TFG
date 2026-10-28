using TMPro;
using UnityEngine;
using UnityEngine.UI;
using KickOffRivals.Presentation.ViewModels;

namespace KickOffRivals.Presentation.Views
{
    public sealed class MatchHudView : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private Button finishButton;

        private MatchHudViewModel _viewModel;
        public void Bind(MatchHudViewModel viewModel)
        {
            Unbind();

            _viewModel = viewModel;
            scoreText.text = viewModel.ScoreText;

            finishButton.onClick.AddListener(OnFinishClicked);
        }

        private void OnFinishClicked()
        {
            _viewModel?.FinishMatch();
        }

        public void Unbind()
        {
            if(finishButton != null)
            {
                finishButton.onClick.RemoveListener(OnFinishClicked);
            }

            _viewModel = null;
        }

        private void OnDestroy()
        {
            Unbind();
        }
    }
}