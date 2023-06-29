using Managers;
using UnityEngine;

namespace Controllers.LifeControllers
{
    public class BaloonLifeController : LifeController
    {
        public GameObject explosionPrefab;
        private void Start()
        {
            EventManager.instance.EventBaloonSpawn();
        }

        protected override void Die()
        {
            base.Die();
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            EventManager.instance.EventBaloonKill();
        }
    }
}