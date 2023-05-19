using System;
using Flyweight;
using UnityEngine;

namespace Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundController : MonoBehaviour
    {
        public static SoundController instace;
        
        [SerializeField] private SoundsLibrary _soundsLibrary;
        public SoundsLibrary SoundsLibrary => _soundsLibrary;

        protected AudioSource _audioSource;

        protected virtual void Awake()
        {
            if(instace != null) Destroy(this);
            instace = this;
            
            _audioSource = GetComponent<AudioSource>();
        }
        
        public void PlaySound(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}