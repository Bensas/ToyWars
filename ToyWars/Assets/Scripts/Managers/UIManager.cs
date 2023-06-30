using System;
using Strategy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
        
        [SerializeField] private TMP_Text _healthDisplay;
        [SerializeField] private TMP_Text _ammoDisplay;
        [SerializeField] private TMP_Text _EnemiesAliveDisplay;
        [SerializeField] private Image _DamageFlash;

        [SerializeField] private TMP_Text _missileCountDisplay;
        [SerializeField] private TMP_Text _turretCountDisplay;
        
        [SerializeField] private GameObject _turretSelected;
        [SerializeField] private GameObject _missileSelected;

        private void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
        }
        
        private void Start()
        {
            EventManager.instance.OnPlayerHealthChange += UpdateHealthDisplay;
            EventManager.instance.OnPlayerHealthChange += ActivateDamageFlash;
            EventManager.instance.OnPlayerAmmoUpdate += UpdateAmmoDisplay;
            EventManager.instance.OnPlayerWeaponChange += UpdateWeaponDisplay;
        }
        
        public void UpdateEnemyAliveDisplay(int enemiesAlive)
        {
            _EnemiesAliveDisplay.text = $"Enemies Alive: {enemiesAlive}";
        }
        
        public void UpdateHealthDisplay(float currentHealth, float maxHealth)
        {
            _healthDisplay.text = $"Health: {currentHealth}/{maxHealth}";

        }

        private void ActivateDamageFlash(float currentHealth, float maxHealth)
        {
            Color temp = _DamageFlash.color;
            temp.a = 1.0f;
            _DamageFlash.color = temp;
        }
        
        private void UpdateAmmoDisplay(IWeapon weapon)
        {
            if (weapon is MissileLauncher)
            {
                _missileCountDisplay.text = weapon.CurrentProjectileCount.ToString();
            }
            else
            {
                _turretCountDisplay.text = weapon.CurrentProjectileCount.ToString();
            }
        }
        
        private void UpdateWeaponDisplay(IWeapon weapon)
        {
            if (weapon is MissileLauncher)
            {
                _missileSelected.SetActive(true);
                _turretSelected.SetActive(false);
            }
            else
            {
                _missileSelected.SetActive(false);
                _turretSelected.SetActive(true);
            }
        }
    }
}