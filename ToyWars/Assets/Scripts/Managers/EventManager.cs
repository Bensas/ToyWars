using System;
using Strategy;
using UnityEngine;
using Flyweight;
using JetBrains.Annotations;

namespace Managers
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager instance;
        
        public event Action<bool> OnGameOver;
        public event Action OnEnemyKill;
        public event Action OnTankKill;
        public event Action OnEnemySpawn;
        public event Action<BaloonType> OnBaloonKill;
        public event Action OnBaloonSpawn;
        public event Action<float, float> OnPlayerHealthChange;
        public event Action<float, float> OnPlayerBuff;
        public event Action<IWeapon> OnPlayerShoot;
        public event Action<IWeapon> OnPlayerAmmoUpdate; 
        public event Action<bool, IWeapon> OnPlayerShootingUpdate;
        public event Action<IWeapon> OnPlayerReloadUpdate;
        public event Action<IWeapon> OnPlayerWeaponChange; 
        public event Action<Vector3, float> OnBombExplode;
        public event Action OnBossDeath;
        public event Action<float, float> OnBossDamaged;

        
        private void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        public void EventGameOver(bool isVictory) => OnGameOver?.Invoke(isVictory);
        public void EventEnemyKill() => OnEnemyKill?.Invoke();
        public void EventTankKill() => OnTankKill?.Invoke();
        public void EventEnemySpawn() => OnEnemySpawn?.Invoke();
        public void EventBaloonKill(BaloonType type) => OnBaloonKill?.Invoke(type);
        public void EventBaloonSpawn() => OnBaloonSpawn?.Invoke();
        public void EventPlayerHealthChange(float currentHealth, float maxHealth) => OnPlayerHealthChange?.Invoke(currentHealth, maxHealth);
        public void EventPlayerBuff(float currentHealth, float maxHealth) => OnPlayerBuff?.Invoke(currentHealth, maxHealth);
        public void EventPlayerShoot(IWeapon currentWeapon) => OnPlayerShoot?.Invoke(currentWeapon);
        public void EventPlayerAmmoUpdate(IWeapon currentWeapon) => OnPlayerAmmoUpdate?.Invoke(currentWeapon);
        public void EventShootingUpdate(bool isShooting, IWeapon weapon) => OnPlayerShootingUpdate?.Invoke(isShooting, weapon);
        public void EventReloadUpdate(IWeapon weapon) => OnPlayerReloadUpdate?.Invoke(weapon);
        public void EventWeaponChange(IWeapon weapon) => OnPlayerWeaponChange?.Invoke(weapon);
        public void EventBombExplode(Vector3 explodePosition, float radius) => OnBombExplode?.Invoke(explodePosition, radius);
        public void EventBossDeath() => OnBossDeath?.Invoke();
        public void EventBossDamaged(float currentHealth, float maxHealth) => OnBossDamaged?.Invoke(currentHealth, maxHealth);

    }
}