using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "ProjectileStats", menuName = "Stats/Projectile", order = 0)]
    public class ProjectileStats : ScriptableObject
    {
        [SerializeField] private StatValues _statValues;
        
        public float Damage => _statValues.damage;
        public float Speed => _statValues.speed;
        public float LifeTime => _statValues.lifeTime;
        
        [System.Serializable]
        public struct StatValues
        {
            public float damage;
            public float speed;
            public float lifeTime;
        }
    }
    
}