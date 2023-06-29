using Managers;
using UnityEngine;

namespace Controllers.LifeControllers
{
    public class EnemyLifeController : LifeController
    {
        private bool isDead = false;
        private void Start()
        {
            EventManager.instance.EventEnemySpawn();
        }

        protected override void Die()
        {
            if (!isDead)
            {
                EventManager.instance.EventEnemyKill();
                isDead = true;
                base.Die();
            }
        }
    }
}