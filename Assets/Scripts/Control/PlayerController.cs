using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.RunnerGame.Control {

    public class PlayerController : MonoBehaviour {

        [SerializeField]
        private float runnigSpeed = 5f;

        [SerializeField]
        private float movingSpeed = 5f;

        public Rigidbody rb { get; private set; }
        public Animator animator { get; private set; }
        public bool isMoving { get; set; } = false;

        private void Awake() {

            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {

            if (isMoving) {

                rb.MovePosition(transform.position + (Vector3.forward * runnigSpeed * Time.fixedDeltaTime));

                if (Input.GetKey(KeyCode.Mouse1))
                    rb.MovePosition(transform.position + (Vector3.forward * runnigSpeed * Time.fixedDeltaTime) + (Vector3.right * movingSpeed * Time.fixedDeltaTime));

                else if (Input.GetKey(KeyCode.Mouse0))
                    rb.MovePosition(transform.position + (Vector3.forward * runnigSpeed * Time.fixedDeltaTime) + (Vector3.left * movingSpeed * Time.fixedDeltaTime));
            }
        }

        private void Update() {

            if (Input.GetKey(KeyCode.Mouse0)) {
                
                animator.SetBool("isRunning", true);
                isMoving = true;
            }                
        }
    }
}

