using System;
using Flyweight;
using Managers;
using Strategy;
using Unity.VisualScripting;
using UnityEngine;

namespace Weapons
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] protected WeaponStats _stats;

        [SerializeField] protected int _currentProjectileCount;
        [SerializeField] protected float _currentShotCooldown;
        [SerializeField] protected float _currentReloadCooldown;
        
        public GameObject ProjectilePrefab => _stats.ProjectilePrefab;
        public float Damage => _stats.Damage;
        public int MaxProjectileCount => _stats.MaxProjectileCount;
        public float ShotCooldown => _stats.ShotCooldown;
        public float ReloadCooldown => _stats.ReloadCooldown;
        
        private void Start()
        {
            _currentProjectileCount = MaxProjectileCount;
            _currentReloadCooldown = ReloadCooldown;
            _currentShotCooldown = ShotCooldown;
        }
        
        private void Update()
        {
            if (_currentShotCooldown > 0) _currentShotCooldown -= Time.deltaTime;
            if (_currentProjectileCount <= 0)
            {
                if (_currentReloadCooldown > 0) _currentReloadCooldown -= Time.deltaTime;
                else Reload();
            }
        }
        
        public void Attack()
        {
            if (_currentShotCooldown <= 0 && _currentProjectileCount > 0)
            {
                var projectile = Instantiate(ProjectilePrefab, transform.position, transform.rotation);
                projectile.GetComponent<IProjectile>().SetOwner(this);
                _currentShotCooldown = ShotCooldown;
                _currentProjectileCount--;
            }
            UpdateAmmoUI();
        }

        private void Reload()
        {
            _currentProjectileCount = MaxProjectileCount;
            _currentReloadCooldown = ReloadCooldown;
            UpdateAmmoUI();
        }
        
        public void UpdateAmmoUI() => EventManager.instance.EventPlayerAmmoChange(_currentProjectileCount);
    }
}