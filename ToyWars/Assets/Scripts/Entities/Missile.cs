using System;
using Commands;
using Flyweight;
using Managers;
using Strategy;
using Unity.VisualScripting;
using UnityEngine;

namespace Entities
{
    public class Missile : MonoBehaviour, IMissile
    {
        [SerializeField] private ProjectileStats _stats;
        [SerializeField] private IWeapon _owner;
        
        [SerializeField] private GameObject _explosionPrefab;
        
        private IRadar _radar;
        private ILockable target;
        private bool locked = false;
        private Rigidbody rigidBody;

        public IWeapon Owner => _owner;
        public float Damage => _stats.Damage;
        public float MaxSpeed => _stats.Speed;
        private float currentSpeed;
        
        public float LifeTime => _stats.LifeTime;
        public float Speed => currentSpeed;
        public float AngleChangingSpeed => _stats.AngleChangingSpeed;
        
        [SerializeField] private float _currentLifetime;

        public void Travel()
        {

            if (target != null && locked)
            {
                // Calculate direction towards the target
                Vector3 direction = (target.GetPosition() - transform.position).normalized;
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
                
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * AngleChangingSpeed);
            }
            
            transform.Translate(Vector3.forward * (currentSpeed * Time.deltaTime));

            currentSpeed += (1 - (currentSpeed / MaxSpeed)) * Time.deltaTime;
        }

        public void SetOwner(IWeapon owner) => _owner = owner;

        public void SetRadar(IRadar radar)
        {
            _radar = radar;
            target = _radar.Target;
        }

        private void Update()
        {
            if (target.IsUnityNull()) // Target has been destroyed
                target = null;
            
            locked = target != null && _radar.Target == target;

            Travel();
            
            _currentLifetime -= Time.deltaTime;
            if (_currentLifetime <= 0) Explode();
        }
        
        public void OnCollisionEnter(Collision collision)
        {
            if (_stats.LayerMasks.Contains(collision.gameObject.layer))
            {
                IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
                if (damageable != null) GliderEventQueueManager.instance.AddEvent(new CmdApplyDamage(damageable, Damage));
            }

            Explode();
        }

        private void Explode()
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        private void Start()
        {
            _currentLifetime = LifeTime;
            rigidBody = GetComponent<Rigidbody>();
            currentSpeed = MaxSpeed * 0.5f;
        }
    }
}