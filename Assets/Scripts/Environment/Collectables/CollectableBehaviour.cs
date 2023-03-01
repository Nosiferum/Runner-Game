using System;
using System.Collections;
using System.Collections.Generic;
using DogukanKarabiyik.RunnerGame.Control;
using DogukanKarabiyik.RunnerGame.Managers;
using UnityEngine;

namespace DogukanKarabiyik.RunnerGame.Environment.Collectables
{
    public class CollectableBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (gameObject.CompareTag("Diamond"))
                {
                    other.GetComponent<PlayerController>().UpdateLocalScore(5);
                    Destroy(gameObject);
                }
                
                else if (gameObject.CompareTag("Diamond5side"))
                {
                    other.GetComponent<PlayerController>().UpdateLocalScore(10);
                    Destroy(gameObject);
                }
            }
        }
    }
}