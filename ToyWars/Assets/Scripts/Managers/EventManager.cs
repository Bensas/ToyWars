using System;
using Strategy;
using UnityEngine;

namespace Managers
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager instance;
        
        public event Action<bool> OnGameOver;
        public event Action OnEnemyKill;
        public event Action OnEnemySpawn;
        public event Action OnBaloonKill;
        public event Action OnBaloonSpawn;
        public event Action<float, float> OnPlayerHealthChange;
        public event Action<IWeapon> OnPlayerShoot;
        public event Action<IWeapon> OnPlayerAmmoUpdate; 
        public event Action<bool, IWeapon> OnPlayerShootingUpdate;
        public event Action<IWeapon> OnPlayerReloadUpdate;
        public event Action<IWeapon> OnPlayerWeaponChange; 

        
        private void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
        }
        
        public void EventGameOver(bool isVictory) => OnGameOver?.Invoke(isVictory);
        public void EventEnemyKill() => OnEnemyKill?.Invoke();
        public void EventEnemySpawn() => OnEnemySpawn?.Invoke();
        public void EventBaloonKill() => OnBaloonKill?.Invoke();
        public void EventBaloonSpawn() => OnBaloonSpawn?.Invoke();
        public void EventPlayerHealthChange(float currentHealth, float maxHealth) => OnPlayerHealthChange?.Invoke(currentHealth, maxHealth);
        public void EventPlayerShoot(IWeapon currentWeapon) => OnPlayerShoot?.Invoke(currentWeapon);
        public void EventPlayerAmmoUpdate(IWeapon currentWeapon) => OnPlayerAmmoUpdate?.Invoke(currentWeapon);
        public void EventShootingUpdate(bool isShooting, IWeapon weapon) => OnPlayerShootingUpdate?.Invoke(isShooting, weapon);
        public void EventReloadUpdate(IWeapon weapon) => OnPlayerReloadUpdate?.Invoke(weapon);
        public void EventWeaponChange(IWeapon weapon) => OnPlayerWeaponChange?.Invoke(weapon);

    }
}