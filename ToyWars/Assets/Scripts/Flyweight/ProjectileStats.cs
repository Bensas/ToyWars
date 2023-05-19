using System.Collections.Generic;
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
        public List<int> LayerMasks => _statValues.layerMasks;
        
        
        [System.Serializable]
        public struct StatValues
        {
            public float damage;
            public float speed;
            public float lifeTime;
            public List<int> layerMasks;
        }
    }
    
}