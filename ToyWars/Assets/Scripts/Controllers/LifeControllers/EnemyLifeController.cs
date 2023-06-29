using Managers;
using UnityEngine;

namespace Controllers.LifeControllers
{
    public class EnemyLifeController : LifeController
    {
        public GameObject explosionPrefab;
        private bool isDead = false;
        private void Start()
        {
            EventManager.instance.EventEnemySpawn();
        }

        protected override void Die()
        {
            if (!isDead)
            {
                isDead = true;
                var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
                EventManager.instance.EventEnemyKill();
                base.Die();
            }
        }
    }
}