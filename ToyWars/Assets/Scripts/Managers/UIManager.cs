using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
        
        [SerializeField] private TMP_Text _healthDisplay;
        [SerializeField] private TMP_Text _ammoDisplay;
        [SerializeField] private TMP_Text _EnemiesAliveDisplay;

        private void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
        }
        
        private void Start()
        {
            EventManager.instance.OnPlayerHealthChange += UpdateHealthDisplay;
            EventManager.instance.OnPlayerAmmoChange += UpdateAmmoDisplay;
        }
        
        public void UpdateEnemyAliveDisplay(int enemiesAlive)
        {
            _EnemiesAliveDisplay.text = $"Enemies Alive: {enemiesAlive}";
        }
        
        public void UpdateHealthDisplay(float currentHealth, float maxHealth)
        {
            _healthDisplay.text = $"Health: {currentHealth}/{maxHealth}";
        }
        
        private void UpdateAmmoDisplay(int currentAmmo)
        {
            _ammoDisplay.text = $"Ammo: {currentAmmo}";
        }
    }
}