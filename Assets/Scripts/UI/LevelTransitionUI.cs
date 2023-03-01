using DogukanKarabiyik.RunnerGame.Control;
using DogukanKarabiyik.RunnerGame.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DogukanKarabiyik.RunnerGame.UI
{
    public class LevelTransitionUI : MonoBehaviour
    {
        [Header("Level End")]
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;

        [Header("Buttons")]
        [SerializeField] private Button nextButton;
        [SerializeField] private Button retryButton;
        
        [Header("Texts")] 
        [SerializeField] private TextMeshProUGUI localScoreSuccessText;
        [SerializeField] private TextMeshProUGUI localScoreFailText;

        private PlayerController _playerController;
        
        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
        }

        private void NextLevel()
        {
            StartCoroutine(SceneController.NextLevel());
            nextButton.interactable = false;
        }

        private void Retry()
        {
            StartCoroutine(SceneController.CurrentLevel());
            retryButton.interactable = false;
        }

        private void UpdateSuccessLocalScoreUI()
        {
            localScoreSuccessText.text = $"You Gained: {_playerController.LocalScore} points!";
        }
        
        private void UpdateFailLocalScoreUI()
        {
            localScoreFailText.text = $"You Lost: {_playerController.LocalScore} points!";
        }

        private void ShowWinUI()
        {
            winPanel.SetActive(true);
            UpdateSuccessLocalScoreUI();
        }

        private void ShowLoseUI()
        {
            losePanel.SetActive(true);
            UpdateFailLocalScoreUI();
        }

        private void OnEnable()
        {
            if (nextButton != null)
                nextButton.onClick.AddListener(NextLevel);
            if (retryButton != null)
                retryButton.onClick.AddListener(Retry);
            
            StaticGameManager.OnLevelSuccess += ShowWinUI;
            StaticGameManager.OnLevelFail += ShowLoseUI;
        }

        private void OnDisable()
        {
            if (nextButton != null)
                nextButton.onClick.RemoveListener(NextLevel);
            if (retryButton != null)
                retryButton.onClick.RemoveListener(Retry);
            
            StaticGameManager.OnLevelSuccess -= ShowWinUI;
            StaticGameManager.OnLevelFail -= ShowLoseUI;
        }
    }
}