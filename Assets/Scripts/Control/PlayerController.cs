using System;
using DogukanKarabiyik.PlatformRunner.Managers;
using DogukanKarabiyik.RunnerGame.Managers;
using UnityEngine;

namespace DogukanKarabiyik.RunnerGame.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed = 5f;
        [SerializeField] private float horizontalSpeed = 5f;

        public int Health { get; set; } = 3;
        public int LocalScore { get; set; } = 0;

        public Action OnHealthChanged;
        public Action OnPlayerDead;
        public Action OnScoreChanged;

        private Rigidbody _rb;
        private Animator _animator;
        private CoinManager _coinManager;
        
        private Action _playerState;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
            
            _coinManager = FindObjectOfType<CoinManager>();
        }

        private void FixedUpdate()
        {
            _playerState?.Invoke();
        }

        public void DamagePlayer(int damage)
        {
            Health -= Mathf.Min(Health, damage);
            OnHealthChanged?.Invoke();

            if (Health == 0)
            {
                OnPlayerDead?.Invoke();
                StaticGameManager.GameFail();
            }
        }

        public void UpdateLocalScore(int score)
        {
            LocalScore += score;
            OnScoreChanged?.Invoke();
        }

        private void GamePlayState()
        {
            Move();
        }

        private void Move()
        {
            _rb.MovePosition(transform.position + (Vector3.forward * (forwardSpeed * Time.fixedDeltaTime)));

            if (Input.GetMouseButton(0))
                _rb.MovePosition(transform.position + (Vector3.forward * (forwardSpeed * Time.fixedDeltaTime)) +
                                 new Vector3(InputManager.Delta.x, 0, 0) * (horizontalSpeed * Time.fixedDeltaTime));
        }
        
        private void SetStartingAnimation()
        {
            _animator.SetBool("isRunning", true);
        }

        private void SetSuccessAnimation()
        {
            _animator.SetBool("isWon", true);
        }

        private void SetFailAnimation()
        {
            _animator.SetBool("isRunning", false);
        }

        private void StartBroadcast()
        {
            SetStartingAnimation();
            _playerState = GamePlayState;
        }

        private void SuccessBroadcast()
        {
            _playerState = null;
            SetSuccessAnimation();
            _coinManager.TakeCoin(LocalScore);
        }

        private void FailBroadcast()
        {
            _playerState = null;
            SetFailAnimation();
        }

        private void OnEnable()
        {
            StaticGameManager.OnLevelStart += StartBroadcast;
            StaticGameManager.OnLevelSuccess += SuccessBroadcast;
            StaticGameManager.OnLevelFail += FailBroadcast;
        }

        private void OnDisable()
        {
            StaticGameManager.OnLevelStart -= StartBroadcast;
            StaticGameManager.OnLevelSuccess -= SuccessBroadcast;
            StaticGameManager.OnLevelFail -= FailBroadcast;
        }
    }
}