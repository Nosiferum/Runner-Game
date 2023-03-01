using DogukanKarabiyik.RunnerGame.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace DogukanKarabiyik.RunnerGame.UI
{
    public class Transition : MonoBehaviour
    {
        private Button _button;
    
        private void Awake()
        {
            SceneController.InitiateThisClass();
            _button = GetComponent<Button>();
        }
    
        private void StartGame()
        {
            StartCoroutine(SceneController.CurrentLevel());
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(StartGame);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(StartGame);
        }
    }
}
