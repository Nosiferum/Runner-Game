using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.RunnerGame.Control;

namespace DogukanKarabiyik.RunnerGame.Environment.Obstacles
{
    public class ObstacleBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().DamagePlayer(1);
                Destroy(gameObject);
            }
        }
    }
}