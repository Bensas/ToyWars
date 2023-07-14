using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Entities;
using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private static string _currentLevelScene = "LivingRoom";  
        
        [SerializeField] private int _currentEnemiesAlive = 0;
        
        [SerializeField] private bool _isGameOver = false;
        [SerializeField] private bool _isVictory = false;
        [SerializeField] private float _delaySceneSwitch = 5f;

        private Glider _playerGlider;

        [SerializeField] private CinemachineVirtualCamera _bossCamera;
        [SerializeField] private CinemachineVirtualCamera _playerCamera;

        private Boss _boss;

        [SerializeField] private int _maxEnemiesAlive = 0;
        [SerializeField] private AudioSource _musicAudioSource;
        public bool IsBossBattle { get; private set; } = false;

        public void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
            
            Cursor.visible = false;
            EventManager.instance.OnEnemyKill += OnEnemyKill;
            EventManager.instance.OnEnemySpawn += OnEnemySpawn;
            EventManager.instance.OnGameOver += OnGameOver;
            EventManager.instance.OnBossDeath += onBossDeath;
        }

        private void OnGameOver(bool isVictory)
        {
            _musicAudioSource.Stop();

            if (!IsBossBattle && _playerCamera != null)
            {
                _playerCamera.Follow = null;
            }

            if (isVictory)
            {
                bool existsNextLevel = GameSceneManager.Instance.IncrementLevel();
                if(existsNextLevel) StartCoroutine(ToNextLevel(_delaySceneSwitch));
                else StartCoroutine(ToEndScene(_delaySceneSwitch, true));
            }
            else
            {
                StartCoroutine(ToEndScene(_delaySceneSwitch/2, false));
            }
        }

        private void OnEnemyKill()
        {
            _currentEnemiesAlive -= 1;
            UIManager.instance.UpdateEnemyAliveDisplay(_currentEnemiesAlive);

            if (_currentEnemiesAlive <= 0) EventManager.instance.EventGameOver(!IsBossBattle);
        }

        private void OnEnemySpawn()
        {
            _currentEnemiesAlive += 1;
            UIManager.instance.UpdateEnemyAliveDisplay(_currentEnemiesAlive);
        }
        
        private void onBossDeath()
        {
            EventManager.instance.EventGameOver(true);
            _bossCamera.Priority = 100;
        }
        
        public int GetEnemiesAlive() => _currentEnemiesAlive;
        
        public void SetPlayerGlider(Glider playerGlider) => _playerGlider = playerGlider;
        public Glider GetPlayerGlider() => _playerGlider;
        public void SetBoss(Boss boss)
        {
            IsBossBattle = true; 
            _boss = boss;
            _bossCamera = _boss.GetComponentInChildren<CinemachineVirtualCamera>();
        }

        private IEnumerator ToEndScene(float delay, bool isVictory)
        {
            yield return new WaitForSeconds(delay);
            if(isVictory) GameSceneManager.Instance.LoadVictoryScene();
            else GameSceneManager.Instance.LoadDefeatScene();
        }
        
        private IEnumerator ToNextLevel(float delay)
        {
            yield return new WaitForSeconds(delay);
            GameSceneManager.Instance.LoadLoadingScene();
        }
    }
}