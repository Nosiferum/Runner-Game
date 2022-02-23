using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.RunnerGame.UI {

    public class ButtonHandler : MonoBehaviour {
       
        public void RestartGame() {

            GameManagement.GameManager.instance.sceneToLoad = "Level" + GameManagement.GameManager.instance.levelIndex.ToString();
            GameManagement.GameManager.instance.RestartGame();
        }

        public void StartGame() {

            GameManagement.GameManager.instance.sceneToLoad = "Level" + GameManagement.GameManager.instance.levelIndex.ToString();
            GameManagement.GameManager.instance.StartGame();
        }

        public void LoadNextLevel() {

            GameManagement.GameManager.instance.levelIndex++;
            GameManagement.GameManager.instance.sceneToLoad = "Level" + GameManagement.GameManager.instance.levelIndex.ToString();
            GameManagement.GameManager.instance.RestartGame();
        }
    }
}

    
