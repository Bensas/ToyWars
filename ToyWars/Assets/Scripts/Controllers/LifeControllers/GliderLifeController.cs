using Managers;
using UnityEngine;

namespace Controllers.LifeControllers
{
    public class GliderLifeController : LifeController
    {
        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            EventManager.instance.EventPlayerHealthChange(CurrentLife, MaxLife);
        }

        protected override void Die()
        {
            base.Die();
            EventManager.instance.EventGameOver(false);
        }
    }
}