using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Managers;
using UnityEngine;

namespace Controllers.LifeControllers
{
    public class BossLifeController : LifeController
    {
        public List<GameObject> explosions;
        public GameObject onDeathObject;
        private List<AudioSource> _audioSources;
        
        private bool _isDead = false;

        protected override void Start()
        {
            base.Start();
            _audioSources = onDeathObject.GetComponents<AudioSource>().ToList();
        }
        
        public override void TakeDamage(float damage)
        {
            if (!_isDead)
            {
                _currentLife -= damage;
                if (_currentLife <= 0) Die();
                EventManager.instance.EventBossDamaged(this._currentLife, this.MaxLife);
            }
        }
        
        protected override void Die()
        {
            if (_isDead) return;
            _isDead = true;
            EventManager.instance.EventBossDeath();
            onDeathObject.SetActive(true);
            StartCoroutine(Explode());
            StartCoroutine(ExplodeSound());

        }


        IEnumerator ExplodeSound()
        {
            foreach (var t in _audioSources)
            {
                t.Play();
                yield return new WaitForSeconds(t.clip.length / 2);
            }
        }
       
        IEnumerator Explode()
        {
            foreach (var t in explosions)
            {
                t.SetActive(true);
                yield return new WaitForSeconds(Random.Range(0.2f, 1f));
            }
        }
    }
}