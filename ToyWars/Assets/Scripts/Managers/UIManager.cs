using System;
using System.Collections;
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
        
        [SerializeField] private Image _healthBar;
        [SerializeField] private TMP_Text _EnemiesAliveDisplay;
        [SerializeField] private Image _DamageFlash;

        [SerializeField] private TMP_Text _missileCountDisplay;
        [SerializeField] private TMP_Text _turretCountDisplay;
        
        [SerializeField] private GameObject _turretSelected;
        [SerializeField] private GameObject _missileSelected;
        
        [SerializeField] private Image _missileReloadBar;
        [SerializeField] private Image _turretReloadBar;

        private void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
        }
        
        private void Start()
        {
            EventManager.instance.OnPlayerHealthChange += UpdateHealthDisplay;
            EventManager.instance.OnPlayerBuff += UpdateHealthDisplay;
            EventManager.instance.OnPlayerHealthChange += ActivateDamageFlash;
            EventManager.instance.OnPlayerAmmoUpdate += UpdateAmmoDisplay;
            EventManager.instance.OnPlayerWeaponChange += UpdateWeaponDisplay;
            EventManager.instance.OnPlayerReloadUpdate += UpdateReloadBar;
        }
        
        public void UpdateEnemyAliveDisplay(int enemiesAlive)
        {
            _EnemiesAliveDisplay.text = $"{enemiesAlive}";
        }
        
        public void UpdateHealthDisplay(float currentHealth, float maxHealth)
        {
            _healthBar.fillAmount = currentHealth / maxHealth;
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
        
        private void UpdateReloadBar(IWeapon weapon)
        {
            if (!weapon.IsReloading) return;
            StartCoroutine(weapon is MissileLauncher
                ? ReloadBarFill(_missileReloadBar, weapon.ReloadCooldown)
                : ReloadBarFill(_turretReloadBar, weapon.ReloadCooldown));
        }
        
        IEnumerator ReloadBarFill(Image bar, float reloadTime)
        {
            float time = 0.0f;
            while (time < reloadTime)
            {
                bar.fillAmount = time / reloadTime;
                time += Time.deltaTime;
                yield return null;
            }
            bar.fillAmount = 0.0f;
        }
    }
}