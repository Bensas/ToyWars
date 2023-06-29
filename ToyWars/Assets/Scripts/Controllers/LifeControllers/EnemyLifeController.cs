using Managers;
using UnityEngine;

namespace Controllers.LifeControllers
{
    public class EnemyLifeController : LifeController
    {
        public GameObject explosionPrefab;
        private void Start()
        {
            EventManager.instance.EventEnemySpawn();
        }

        protected override void Die()
        {
            base.Die();
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            EventManager.instance.EventEnemyKill();
        }
    }
}