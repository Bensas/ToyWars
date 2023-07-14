using Entities;
using Managers;
using Strategy;
using UnityEngine;

namespace Controllers.LifeControllers
{
    [RequireComponent(typeof(Actor))]
    public class LifeController : MonoBehaviour, IDamageable
    {
        public bool IsDead() => _currentLife <= 0;
        public float CurrentLife => _currentLife;
        [SerializeField] protected float _currentLife;

        public float MaxLife { get; private set; }

        protected virtual void Start()
        {
            MaxLife = GetComponent<Actor>().Stats.MaxLife;
            _currentLife = MaxLife;
        }
        
        public virtual void TakeDamage(float damage)
        {
            _currentLife -= damage;
            if (IsDead()) Die();
        }
        
        

        protected virtual void Die() 
        {
            Destroy(this.gameObject); 
        }
    }
}