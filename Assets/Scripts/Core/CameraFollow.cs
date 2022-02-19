using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.RunnerGame.Core {

    public class CameraFollow : MonoBehaviour {

        [SerializeField]
        private Transform player;

        [SerializeField]
        private float distance = 10;

        [SerializeField]
        private float height = 5;

        [SerializeField]
        private float cameraSpeed = 100;
       
        void FixedUpdate() {

            if (!player)
                return;

            Vector3 targetPos = player.transform.position + Vector3.up * height - Vector3.forward * distance;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.fixedDeltaTime * cameraSpeed);
        }
    }
}
