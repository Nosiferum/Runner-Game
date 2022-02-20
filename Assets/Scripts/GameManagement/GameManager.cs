using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using DogukanKarabiyik.RunnerGame.Control;
using TMPro;

namespace DogukanKarabiyik.RunnerGame.GameManagement {

    public class GameManager : MonoBehaviour {

        [SerializeField]
        private TextMeshProUGUI localScoreText;

        [SerializeField]
        private TextMeshProUGUI healthText;

        [SerializeField]
        private TextMeshProUGUI scoreText;

        [SerializeField]
        private TextMeshProUGUI localScoreVictoryText;

        [SerializeField]
        private TextMeshProUGUI sceneNameText;

        [SerializeField]
        private TextMeshProUGUI localScoreLostText;


        private static GameManager _instance;
        private int score;
        private bool isScoreAdded = false;   
        private bool isEndScreen = true;
        private float timer = 3;
        private string sceneName;
        
        public PlayerController player { get; private set; }
        public int localScore { get; set; }
        public string sceneToLoad { get; set; }

        public static GameManager instance {
            get {
                if (_instance == null)
                    Debug.LogError("Scene Manager is Null!");

                return _instance;
            }
        }

        private void Awake() {

            InitializeGameManager();
            player = FindObjectOfType<PlayerController>();
        }

        private void Update() {
           
           // RestartGame();            
            HandleScore();
            GetSceneName();
            InitializeUI();
            LoadNextScene();
        }

        private void InitializeGameManager() {

            if (_instance != null && _instance != this)
                Destroy(gameObject);

            else
                _instance = this;

            DontDestroyOnLoad(gameObject);
        }

        public void RestartGame() {

            if (player.isDead)
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        private void InitializeUI() {

            localScoreText.text = "Score: " + localScore;
            healthText.text = "Health: " + player.health;
            scoreText.text = "Your total score: " + score;
            localScoreVictoryText.text = "You have collected: " + localScore + " points!";
            localScoreLostText.text = "You have collected and lost: " + localScore + " points!";
            sceneNameText.text = "Level: " + sceneName;

        }

        private void HandleScore() {

            if (!isEndScreen && isScoreAdded) {

                localScore = 0;
                isScoreAdded = false;
            }
                
            if (player.isWon && !isScoreAdded) {

                score += localScore;
                isScoreAdded = true;
            }
        }

        private void LoadNextScene() {

            if (player.isWon) {

                timer -= Time.deltaTime;

                if (timer <= 0) {

                    player.isWon = false;

                    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);             
                }             
            }
            
            if (player.isDead && isEndScreen) {

                sceneToLoad = "Game Over";
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);

                isEndScreen = false;

            }
        }

        private void GetSceneName() {

            var sceneRawName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            sceneName = Regex.Match(sceneRawName, @"\d+").Value;               
        }
    }
}


