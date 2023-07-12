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

            _audioSource.loop = false;

            AddFunctionToEventManager();
        }

        private void AddFunctionToEventManager() {
          EventManager.instance.OnEnemyKill += PlayEnemyExplosionSound;
          EventManager.instance.OnBaloonKill += PlayExplosionSound;
          EventManager.instance.OnTankKill += PlayEnemyExplosionSound;
          EventManager.instance.OnBombExplode += PlayBombExplosionSound;
        }

        private void PlayExplosionSound(BaloonType type)
        {
            _audioSource.clip = SoundsLibrary.Explosion;
            Play();
        }

        private void PlayEnemyExplosionSound() {
            _audioSource.clip = SoundsLibrary.Explosion;
            Play();
        }

        private void PlayBombExplosionSound(Vector3 position, float radius) {
            _audioSource.clip = SoundsLibrary.BombExplosion;
            Play();
        }
    }
}