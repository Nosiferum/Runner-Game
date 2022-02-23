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

        [SerializeField]
        private TextMeshProUGUI startSceneNameText;

        [SerializeField]
        private TextMeshProUGUI startScoreText;

        private static GameManager _instance;
        private int score;
        private int lastLevelIndex = 2;
        private float winTimer = 3;
        private bool isScoreAdded = false;   
        private bool isEndingScreen = false;
        private bool isGameScreen = false;
        private bool isMenuScreen = true;
        private bool isRestarted = false;
        private bool isLastLevel = false;
        private string sceneName;
        
        public PlayerController player { get; private set; }
        public int localScore { get; set; } = 0;
        public string sceneToLoad { get; set; }
        public bool isPlayerDead { get; set; } = false;
        public bool isPlayerWon { get; set; } = false;
        public int levelIndex { get; set; } = 1;

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

            QuitGame();
            FindPlayer();
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

            isScoreAdded = false;
            isEndingScreen = false;
            isGameScreen = true;
            isPlayerDead = false;
            isPlayerWon = false;
            isRestarted = true;
            winTimer = 3;
            
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);         
    }

        public void StartGame() {

            isGameScreen = true;
            isMenuScreen = false;

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        }

        private void QuitGame() {

            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }

        private void InitializeUI() {

            startSceneNameText.text = "You are on level: " + sceneName;
            startScoreText.text = "Your total score is: " + score;

            if (isGameScreen) {

                localScoreText = GameObject.FindGameObjectWithTag("Local Score").GetComponent<TextMeshProUGUI>();
                healthText = GameObject.FindGameObjectWithTag("Health").GetComponent<TextMeshProUGUI>();
                sceneNameText = GameObject.FindGameObjectWithTag("Scene Name").GetComponent<TextMeshProUGUI>();

                healthText.text = "Health: " + player.health;
                localScoreText.text = "Score: " + localScore;
                sceneNameText.text = "Level: " + sceneName;
            }

            scoreText.text = "Your total score: " + score;
            localScoreVictoryText.text = "You have collected: " + localScore + " points!";
            localScoreLostText.text = "You have collected and lost: " + localScore + " points!";          
        }

        private void HandleScore() {

            if (isRestarted) {          
               
                localScore = 0;             
                isRestarted = false;
            }
                
            if (isPlayerWon && !isScoreAdded) {
              
                score += localScore;
                isScoreAdded = true;            
            }
        }

        private void LoadNextScene() {

            if (isPlayerWon && isGameScreen && !isLastLevel) {

                sceneToLoad = "Level Victory";

                winTimer -= Time.deltaTime;

                if (winTimer <= 0) {

                    isGameScreen = false;
                    
                    if (lastLevelIndex == levelIndex) {

                        isLastLevel = true;
                        sceneToLoad = "Victory";
                    }
                    
                    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
                }
            }
        
            if (isPlayerDead) {

                sceneToLoad = "Game Over";

                isPlayerDead = false;
                isEndingScreen = true;
                isGameScreen = false;

                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);                              
            } 
        }

        private void GetSceneName() {

            if (isGameScreen) {

                var sceneRawName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                sceneName = Regex.Match(sceneRawName, @"\d+").Value;
            } 
            
            if (isMenuScreen) {

                var sceneRawName = "Level1";
                sceneName = Regex.Match(sceneRawName, @"\d+").Value;
            }
        }

        private void FindPlayer() {

            if (player == null && !isEndingScreen)
                player = FindObjectOfType<PlayerController>();
        }
    }
}


