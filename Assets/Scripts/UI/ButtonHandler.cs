using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.RunnerGame.UI {

    public class ButtonHandler : MonoBehaviour {
       
        public void RestartGame() {

            GameManagement.GameManager.instance.sceneToLoad = "Level1";
            GameManagement.GameManager.instance.RestartGame();
        }

        public void StartGame() {

            GameManagement.GameManager.instance.sceneToLoad = "Level1";
            GameManagement.GameManager.instance.StartGame();
        }
    }
}

    
