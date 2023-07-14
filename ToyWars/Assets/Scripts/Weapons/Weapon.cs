using System;
using Entities;
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
        public AudioClip ShotSound => _stats.ShotSound;
        public bool FireOnHold => _stats.FireOnHold;
        public bool IsReloading { get; private set; } = false;
        public int CurrentProjectileCount => _currentProjectileCount;

        private bool _ownerIsPlayer = false;
        protected Actor _owner;

        private void Start()
        {
            _currentProjectileCount = MaxProjectileCount;
            _currentReloadCooldown = ReloadCooldown;
            _currentShotCooldown = ShotCooldown;
        }

        protected void Update()
        {
            if (_currentShotCooldown > 0) _currentShotCooldown -= Time.deltaTime;
            if (_currentProjectileCount <= 0)
            {
                if (!IsReloading) UpdateReloadState(true);
                
                if (_currentReloadCooldown > 0) _currentReloadCooldown -= Time.deltaTime;
                else Reload();
            }
        }
        
        public void Attack()
        {
            if (this == null){
                return;
            }
            if (_currentShotCooldown <= 0 && _currentProjectileCount > 0)
            {
                InstantiateProjectile();
                _currentShotCooldown = ShotCooldown;
                _currentProjectileCount--;
                if(_ownerIsPlayer)
                    EventManager.instance.EventPlayerShoot(this);
            }
            UpdateAmmoUI();
        }
        
        protected virtual GameObject InstantiateProjectile()
        {
            var projectile = Instantiate(ProjectilePrefab, transform.position, transform.rotation);
            projectile.GetComponent<IProjectile>().SetOwner(this);
            return projectile;
        } 

        private void Reload()
        {
            _currentProjectileCount = MaxProjectileCount;
            _currentReloadCooldown = ReloadCooldown;
            UpdateAmmoUI();
            UpdateReloadState(false);
        }
        
        public void UpdateAmmoUI()
        {
            if(_ownerIsPlayer)
                EventManager.instance.EventPlayerAmmoUpdate(this);
        }

        public void UpdateReloadState(bool isReloading)
        {
            IsReloading = isReloading;
            if(_ownerIsPlayer)
                EventManager.instance.EventReloadUpdate(this);
        }
        
        public void SetOwnerIsPlayer(bool isPlayer) => _ownerIsPlayer = isPlayer;
        public virtual void SetOwner(Actor owner) => _owner = owner;
    }
}