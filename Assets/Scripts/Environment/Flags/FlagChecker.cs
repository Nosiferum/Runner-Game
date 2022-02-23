using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.RunnerGame.Control;

namespace DogukanKarabiyik.RunnerGame.Environment.Flags {

    public class FlagChecker : MonoBehaviour {

        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player") {

                var player = other.GetComponent<PlayerController>();

                player.isMoving = false;
                player.animator.SetBool("isWon", true);
                GameManagement.GameManager.instance.isPlayerWon = true;     
            }
        }
    }
}

   
