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
        public AudioClip PlaneEmpty => _soundClips.planeEmpty;
        public AudioClip PlaneFlyLoop => _soundClips.planeFlyLoop;

        public AudioClip BulletHit1 => _soundClips.bulletHi1;
        public AudioClip BulletHit2 => _soundClips.bulletHi2;
        public AudioClip BulletHit3 => _soundClips.bulletHi3;

        public AudioClip Explosion => _soundClips.explosion;
        
        public AudioClip HealthBuff => _soundClips.healthBuff;
        public AudioClip SpeedBuff => _soundClips.speedBuff;
        
        
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
            public AudioClip planeEmpty;
            public AudioClip planeFlyLoop;

            public AudioClip bulletHi1;
            public AudioClip bulletHi2;
            public AudioClip bulletHi3;

            public AudioClip explosion;

            public AudioClip healthBuff;
            public AudioClip speedBuff;
        }
    }
    
}