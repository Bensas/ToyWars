using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "SoundsLibrary", menuName = "Sounds/SoundsLibrary", order = 0)]
    public class SoundsLibrary : ScriptableObject
    {
        [SerializeField] public SoundClips _soundClips;
        
        public AudioClip MenuMusicIntro => _soundClips.menuMusicIntro;
        public AudioClip MenuMusicLoop => _soundClips.menuMusicLoop;
        public AudioClip BedroomMusicLoop => _soundClips.bedroomMusicLoop;
        
        public AudioClip ButtonHighlight => _soundClips.buttonHighlight;
        public AudioClip ButtonClick => _soundClips.buttonClick;
        
        public AudioClip PlaneShoot => _soundClips.planeShoot;
        // public AudioClip PlaneReload => _soundClips.planeReload;
        // public AudioClip PlaneEmpty => _soundClips.planeEmpty;
        public AudioClip PlaneFlyLoop => _soundClips.planeFlyLoop;
        
        
        [System.Serializable]
        public struct SoundClips
        {
            public AudioClip menuMusicIntro; 
            public AudioClip menuMusicLoop;
            public AudioClip bedroomMusicLoop;
            
            public AudioClip buttonHighlight;
            public AudioClip buttonClick;
            
            public AudioClip planeShoot;
            // public AudioClip planeReload;
            // public AudioClip planeEmpty;
            public AudioClip planeFlyLoop;
        }
    }
    
}