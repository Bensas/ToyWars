using Managers;
using UnityEngine;
using Entities;

namespace Controllers.LifeControllers
{
    public class BaloonLifeController : LifeController
    {
        public GameObject explosionPrefab;
        public Baloon bloonRef;
        private void Start()
        {
            
            EventManager.instance.EventBaloonSpawn();
            bloonRef = GetComponent<Baloon>();
        }

        protected override void Die()
        {
            base.Die();
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            EventManager.instance.EventBaloonKill(bloonRef.type);
        }
    }
}