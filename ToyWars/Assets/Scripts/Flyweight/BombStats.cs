using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "BombStats", menuName = "Stats/Bomb", order = 0)]
    public class BombStats : ScriptableObject
    {
        [SerializeField] private StatValues _statValues;
        
        public float Damage => _statValues.damage;
        public float Speed => _statValues.speed;
        
        
        [System.Serializable]
        public struct StatValues
        {
            public float damage;
            public float speed;
        }
    }
    
}