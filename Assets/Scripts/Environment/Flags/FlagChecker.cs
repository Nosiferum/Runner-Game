using UnityEngine;
using DogukanKarabiyik.RunnerGame.Managers;

namespace DogukanKarabiyik.RunnerGame.Environment.Flags
{
    public class FlagChecker : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                StaticGameManager.GameSuccess();
        }
    }
}