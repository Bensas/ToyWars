using Entities;
using Managers;
using Strategy;
using UnityEngine;

namespace Controllers.LifeControllers
{
    [RequireComponent(typeof(Actor))]
    public class LifeController : MonoBehaviour, IDamageable
    {
        public float CurrentLife => _currentLife;
        [SerializeField] private float _currentLife;
        
        public float MaxLife => GetComponent<Actor>().Stats.MaxLife;
        
        void Start()
        {
            _currentLife = MaxLife;
        }
        
        public virtual void TakeDamage(float damage)
        {
            _currentLife -= damage;
            if (IsDead()) Die();
        }
        
        private bool IsDead() => _currentLife <= 0;

        protected virtual void Die() 
        {
            Destroy(this.gameObject); 
        }
    }
}