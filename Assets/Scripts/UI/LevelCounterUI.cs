using DogukanKarabiyik.RunnerGame.Managers;
using TMPro;
using UnityEngine;

namespace DogukanKarabiyik.RunnerGame.UI
{
    public class LevelCounterUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentLevelText;

        private void Start()
        {
            currentLevelText.text = $"Level {SceneController.UILevelIndex}";
        }
    }
}