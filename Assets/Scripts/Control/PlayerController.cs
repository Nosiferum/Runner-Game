using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.RunnerGame.Control {

    public class PlayerController : MonoBehaviour {

        [SerializeField]
        private float runnigSpeed = 5f;

        [SerializeField]
        private float movingSpeed = 5f;

        private bool isMovementActivated = false;
      
        public Rigidbody rb { get; private set; }
        public Animator animator { get; private set; }
        public bool isMoving { get; set; } = false;
        public int health { get; set; } = 3;
        
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

            if (!isMovementActivated) {

                if (Input.GetKey(KeyCode.Mouse0)) {

                    animator.SetBool("isRunning", true);
                    isMoving = true;
                    isMovementActivated = true;
                }              
            } 
            
            if (health <= 0) 
                GameManagement.GameManager.instance.isPlayerDead = true; 
        }
    }
}

