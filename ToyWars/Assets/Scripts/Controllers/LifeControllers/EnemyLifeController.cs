using Managers;

namespace Controllers.LifeControllers
{
    public class EnemyLifeController : LifeController
    {
        private void Start()
        {
            EventManager.instance.EventEnemySpawn();
        }

        protected override void Die()
        {
            base.Die();
            EventManager.instance.EventEnemyKill();
        }
    }
}