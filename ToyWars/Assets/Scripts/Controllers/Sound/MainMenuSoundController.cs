using Flyweight;
using UnityEngine;

namespace Sound
{
    public class MainMenuSoundController : SoundController
    {
        protected override void Awake()
        {
            base.Awake();

            _audioSource = GetComponent<AudioSource>();
            _audioSource.PlayOneShot(SoundsLibrary.MenuMusicIntro);
            
            _audioSource.clip = SoundsLibrary.MenuMusicLoop;
            _audioSource.loop = true;
            _audioSource.PlayDelayed(SoundsLibrary.MenuMusicIntro.length - 0.2f);
        }
    }
}