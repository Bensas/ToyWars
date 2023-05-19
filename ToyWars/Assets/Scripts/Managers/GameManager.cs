using System;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        
        [SerializeField] private int _currentEnemiesAlive = 0;
        
        [SerializeField] private bool _isGameOver = false;
        [SerializeField] private bool _isVictory = false;

        public void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
            
            Cursor.visible = false;
            EventManager.instance.OnEnemyKill += OnEnemyKill;
            EventManager.instance.OnEnemySpawn += OnEnemySpawn;
            EventManager.instance.OnGameOver += OnGameOver;
        }

        private void OnGameOver(bool isVictory)
        {
        }

        private void OnEnemyKill()
        {
            _currentEnemiesAlive -= 1;
        }

        private void OnEnemySpawn()
        {
            _currentEnemiesAlive += 1;
        }
        
        public int GetEnemiesAlive() => _currentEnemiesAlive;
    }
}