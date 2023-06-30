using Flyweight;
using Managers;
using UnityEngine;

namespace Sound
{
    public class BuffSoundController : SoundController
    {
        protected override void Awake()
        {
            base.Awake();

            _audioSource.loop = false;

            AddFunctionToEventManager();
        }

        private void AddFunctionToEventManager() {
          EventManager.instance.OnBaloonKill += PlayBuffSound;
        }

        private void PlayBuffSound(BaloonType type)
        {
            switch (type) {
                case BaloonType.HEALTH:
                    _audioSource.clip = SoundsLibrary.HealthBuff;
                    break;
                case BaloonType.SPEED:
                    _audioSource.clip = SoundsLibrary.SpeedBuff;
                    break;
            }
            Debug.Log("Playing buff sound");
            Play();
        }
    }
}