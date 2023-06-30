using Flyweight;
using Managers;
using UnityEngine;

namespace Sound
{
    public class EnemyBulletSoundController : SoundController
    {
        protected override void Awake()
        {
            base.Awake();

            _audioSource.clip = SoundsLibrary.BulletHit1;
            _audioSource.loop = false;

            AddFunctionToEventManager();
        }

        private void AddFunctionToEventManager() {
          EventManager.instance.OnPlayerHealthChange += OnBulletHitPlayer;
        }

        private void OnBulletHitPlayer(float health1, float health2)
        {
            _audioSource.clip = GetRandomBulletHitSound();
            Play();
        }

        private AudioClip GetRandomBulletHitSound() {
          float rand = Random.value;
          if (rand < 1f/3f) {
            return SoundsLibrary.BulletHit1;
          } else if (rand < 2f/3f) {
            return SoundsLibrary.BulletHit2;
          } else {
            return SoundsLibrary.BulletHit3;
          }
        }
    }
}