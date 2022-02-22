using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.RunnerGame.Control;

namespace DogukanKarabiyik.RunnerGame.Environment.Obstacles {

    public class ObstacleBehaviour : MonoBehaviour {

        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player") {

                other.GetComponent<PlayerController>().health -= 1;
                Destroy(gameObject);                
            }                             
       }
    }
}

    
