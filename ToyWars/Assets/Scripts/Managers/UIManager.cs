using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthDisplay;
        [SerializeField] private TMP_Text _ammoDisplay;
        [SerializeField] private TMP_Text _EnemiesAliveDisplay;

        private void Start()
        {
            EventManager.instance.OnEnemySpawn += UpdateEnemyAliveDisplay;
            EventManager.instance.OnEnemyKill += UpdateEnemyAliveDisplay;
            
            EventManager.instance.OnPlayerHealthChange += UpdateHealthDisplay;
            EventManager.instance.OnPlayerAmmoChange += UpdateAmmoDisplay;
        }
        
        private void UpdateEnemyAliveDisplay()
        {
            _EnemiesAliveDisplay.text = $"Enemies Alive: {GameManager.instance.GetEnemiesAlive()}";
        }
        
        private void UpdateHealthDisplay(float currentHealth, float maxHealth)
        {
            _healthDisplay.text = $"Health: {currentHealth}/{maxHealth}";
        }
        
        private void UpdateAmmoDisplay(int currentAmmo)
        {
            _ammoDisplay.text = $"Ammo: {currentAmmo}";
        }
    }
}