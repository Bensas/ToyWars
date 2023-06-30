using Flyweight;
using Managers;
using UnityEngine;

namespace Sound
{
    public class ExplosionSoundController : SoundController
    {
        protected override void Awake()
        {
            base.Awake();

            _audioSource.clip = SoundsLibrary.Explosion;
            _audioSource.loop = false;

            AddFunctionToEventManager();
        }

        private void AddFunctionToEventManager() {
          EventManager.instance.OnEnemyKill += PlayEnemyExplosionSound;
          EventManager.instance.OnBaloonKill += PlayExplosionSound;
        }

        private void PlayExplosionSound(BaloonType type)
        {
            Play();
        }

        private void PlayEnemyExplosionSound() {
            Play();
        }
    }
}