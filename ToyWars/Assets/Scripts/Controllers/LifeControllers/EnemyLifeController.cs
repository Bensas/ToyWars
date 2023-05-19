using System;
using Managers;
using UnityEngine;

namespace Controllers.LifeControllers
{
    public class EnemyLifeController : LifeController
    {
        private void Awake()
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