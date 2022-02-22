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
        private bool isEndingScreen = false;
        //private bool isVictoryScreen = false;
        private bool isGameScreen = true;
        private bool isRestarted = false;
        private float timer = 3;
        private string sceneName;
        
        public PlayerController player { get; private set; }
        public int localScore { get; set; } = 0;
        public string sceneToLoad { get; set; }
        public bool isDead { get; set; } = false;
        public bool isWon { get; set; } = false;

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
            //isVictoryScreen = false;
            isGameScreen = true;
            isDead = false;
            isWon = false;
            isRestarted = true;

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);         
    }

        private void InitializeUI() {

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
                
            if (isWon && !isScoreAdded) {
              
                score += localScore;
                isScoreAdded = true;            
            }
        }

        private void LoadNextScene() {

            if (isWon && isGameScreen) {

                timer -= Time.deltaTime;

                if (timer <= 0) {

                    isGameScreen = false;
                    //isVictoryScreen = true;

                    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);                  
               }             
            }
            
            if (isDead) {

                sceneToLoad = "Game Over";

                isDead = false;
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
        }

        private void FindPlayer() {

            if (player == null && !isEndingScreen)
                player = FindObjectOfType<PlayerController>();
        }
    }
}


