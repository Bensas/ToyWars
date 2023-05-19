using Flyweight;
using Managers;
using UnityEngine;

namespace Sound
{
    public class GliderSoundController : SoundController
    {
        protected override void Awake()
        {
            base.Awake();

            _audioSource.clip = SoundsLibrary.PlaneShoot;
            _audioSource.loop = true;

            EventManager.instance.OnPlayerShootingUpdate += OnPlayerShootingUpdate;
            EventManager.instance.OnPlayerReloadUpdate += OnPlayerReloadUpdate;
        }

        private void OnPlayerShootingUpdate(bool isShooting)
        {
            if (isShooting) Play();
            else Stop();
        }

        private void OnPlayerReloadUpdate(bool isReloading)
        {
            if (isReloading)
            {
                bool isPlaying = _audioSource.isPlaying;
                _audioSource.clip = SoundsLibrary.PlaneEmpty;
                if(isPlaying) _audioSource.Play();
                
                // Play Reload sound;
            }
            else
            {
                _audioSource.clip = SoundsLibrary.PlaneShoot;
            }
        }
    }
}