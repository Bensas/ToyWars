using System;
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
        public event Action<int> OnPlayerAmmoChange;
        public event Action<bool> OnPlayerShootingUpdate;
        public event Action<bool> OnPlayerReloadUpdate;
        
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
        public void EventPlayerAmmoChange(int currentAmmo) => OnPlayerAmmoChange?.Invoke(currentAmmo);
        public void EventShootingUpdate(bool isShooting) => OnPlayerShootingUpdate?.Invoke(isShooting);
        public void EventReloadUpdate(bool isReloading) => OnPlayerReloadUpdate?.Invoke(isReloading);

    }
}