using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.RunnerGame.Environment.Flags {

    public class FlagChecker : MonoBehaviour {

        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player") {

                var player = GameManagement.GameManager.instance.player;

                player.isMoving = false;
                player.animator.SetBool("isWon", true);
                player.isWon = true;

                GameManagement.GameManager.instance.sceneToLoad = "Victory";
            }
        }
    }
}

   
