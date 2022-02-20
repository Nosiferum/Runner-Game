using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.RunnerGame.Environment.Collectables {

    public class CollectableBehaviour : MonoBehaviour {

        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player") {

                if (gameObject.tag == "Diamond") {

                    GameManagement.GameManager.instance.score += 5;
                    Destroy(gameObject);
                }
                   

                else if (gameObject.tag == "Diamond5side") {

                    GameManagement.GameManager.instance.score += 10;
                    Destroy(gameObject);
                }                  
            }
        }
    }
}

