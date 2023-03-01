using DogukanKarabiyik.RunnerGame.Control;
using TMPro;
using UnityEngine;


public class GameCanvasPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI localScoreText;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    private PlayerController _playerController;
    private CoinManager _coinManager;
    
    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _coinManager = FindObjectOfType<CoinManager>();
    }

    private void Start()
    {
        UpdateHealthUI();
        UpdateLocalScoreUI();
        UpdateTotalScoreUI();
    }

    private void UpdateHealthUI()
    {
        healthText.text = $"Health: {_playerController.Health}";
    }

    private void UpdateLocalScoreUI()
    {
        localScoreText.text = $"Local Score: {_playerController.LocalScore}";
    }

    private void UpdateTotalScoreUI()
    {
        totalScoreText.text = $"Total Score: {_coinManager.TotalCoins}";
    }

    private void OnEnable()
    {
        _playerController.OnHealthChanged += UpdateHealthUI;
        _playerController.OnScoreChanged += UpdateLocalScoreUI;

    }

    private void OnDisable()
    {
        _playerController.OnHealthChanged -= UpdateHealthUI;
        _playerController.OnScoreChanged -= UpdateLocalScoreUI;

    }
}
