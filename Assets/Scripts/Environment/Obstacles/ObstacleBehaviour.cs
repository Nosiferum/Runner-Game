using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.RunnerGame.Control;

namespace DogukanKarabiyik.RunnerGame.Environment.Obstacles {

    public class ObstacleBehaviour : MonoBehaviour {

        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player") {

                GameManagement.GameManager.instance.player.health -= 1;
                Destroy(gameObject);                
            }                             
       }
    }
}

    
