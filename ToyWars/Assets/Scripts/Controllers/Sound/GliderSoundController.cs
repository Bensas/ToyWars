using Managers;
using Sound;
using Strategy;

namespace Controllers.Sound
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
            EventManager.instance.OnPlayerShoot += OnPlayerShoot;
        }

        private void OnPlayerShoot(IWeapon weapon)
        {
            if (!weapon.FireOnHold)
            {
                _audioSource.PlayOneShot(weapon.IsReloading ? SoundsLibrary.PlaneEmpty : weapon.ShotSound);
            }
        }
        
        private void OnPlayerShootingUpdate(bool isShooting, IWeapon weapon)
        {
            if (isShooting && weapon.FireOnHold)
            {
                _audioSource.clip = weapon.IsReloading ? SoundsLibrary.PlaneEmpty : weapon.ShotSound;
                Play();
            }
            else if(!isShooting && weapon.FireOnHold)
            {
                Stop();
            }
            
        }

        private void OnPlayerReloadUpdate(IWeapon weapon)
        {
            if (weapon.IsReloading && weapon.FireOnHold)
            {
                bool isPlaying = _audioSource.isPlaying;
                _audioSource.clip = SoundsLibrary.PlaneEmpty;
                if(isPlaying) _audioSource.Play();
            }
        }
    }
}