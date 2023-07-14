using Managers;
using UnityEngine;

namespace Controllers.LifeControllers
{
    public class GliderLifeController : LifeController
    {
        [SerializeField] private GameObject explosionPrefab;
        [SerializeField] private bool _invincible = false;
        
        protected override void Start()
        {
            base.Start();
            
            UIManager.instance.UpdateHealthDisplay(CurrentLife, MaxLife);
        }
    
        public override void TakeDamage(float damage)
        {
            if(_invincible)
                return;
            
            base.TakeDamage(damage);
            EventManager.instance.EventPlayerHealthChange(CurrentLife, MaxLife);
        }

        protected override void Die()
        {
            base.Die();
            EventManager.instance.EventGameOver(false);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        public void IncreaseLife(float amount)
        {
            _currentLife += amount;
            if (_currentLife > MaxLife) _currentLife = MaxLife;
            EventManager.instance.EventPlayerBuff(CurrentLife, MaxLife);
        }
    }
}