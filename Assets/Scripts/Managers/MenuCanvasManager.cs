using UnityEngine;

namespace DogukanKarabiyik.RunnerGame.Managers
{
    public class MenuCanvasManager : MonoBehaviour
    {
        private void DeactivateParent()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StaticGameManager.GameStart();
                DeactivateParent();
            }
        }
    }
}

