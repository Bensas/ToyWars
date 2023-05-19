using System;
using Flyweight;
using UnityEngine;

namespace Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundController : MonoBehaviour
    {

        [SerializeField] private SoundsLibrary _soundsLibrary;
        public SoundsLibrary SoundsLibrary => _soundsLibrary;

        protected AudioSource _audioSource;

        protected virtual void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        
        public void PlaySound(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }

        public void Play()
        {
            if(!_audioSource.isPlaying)_audioSource.Play();
        }
        
        public void Stop()
        {
            if(_audioSource.isPlaying)_audioSource.Stop();
        }
    }
}