using System;
using Commands;
using Flyweight;
using Managers;
using Strategy;
using UnityEngine;

namespace Entities
{
    public class Bullet : MonoBehaviour, IProjectile
    {
        [SerializeField] private ProjectileStats _stats;
        [SerializeField] private IWeapon _owner;

        public IWeapon Owner => _owner;
        public float Damage => _stats.Damage;
        public float Speed => _stats.Speed;
        public float LifeTime => _stats.LifeTime;

        [SerializeField] private float _currentLifetime;

        private void Start()
        {
            _currentLifetime = LifeTime;
        }
        
        public void Travel() => transform.Translate( 0,0,Speed * Time.deltaTime);

        public void OnCollisionEnter(Collision collision)
        {
            if (_stats.LayerMasks.Contains(collision.gameObject.layer))
            {
                IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
                if (damageable != null) GliderEventQueueManager.instance.AddEvent(new CmdApplyDamage(damageable, Damage));
            }
            
            Destroy(this.gameObject);
        }

        public void SetOwner(IWeapon owner)
        {
            _owner = owner;
        }

        void Update()
        {
            Travel();

            _currentLifetime -= Time.deltaTime;
            if (_currentLifetime <= 0) Destroy(this.gameObject);
        }
    }
}