using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.RunnerGame.Control;

namespace DogukanKarabiyik.RunnerGame.GameManagement {

    public class GameManager : MonoBehaviour {

        private static GameManager _instance;
        
        public PlayerController player { get; private set; }
        public int score { get; set; }

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

            if (player.isDead)
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                
        }

        private void InitializeGameManager() {

            if (_instance != null && _instance != this)
                Destroy(gameObject);

            else
                _instance = this;

            DontDestroyOnLoad(gameObject);
        }
    }
}


