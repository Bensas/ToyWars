using Flyweight;
using Managers;
using Strategy;
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

        private void OnPlayerShootingUpdate(bool isShooting, IWeapon weapon)
        {
            if (isShooting)
            {
                if (weapon.FireOnHold)
                {
                    _audioSource.clip = weapon.ShotSound;
                    Play();   
                }
                else
                    _audioSource.PlayOneShot(weapon.ShotSound);
            }
            else 
                if(weapon.FireOnHold)
                    Stop();
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