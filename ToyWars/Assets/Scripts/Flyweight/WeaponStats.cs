using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "WeaponStats", menuName = "Stats/Weapons", order = 0)]
    public class WeaponStats : ScriptableObject
    {
        [SerializeField] private StatValues _statValues;
        
        public GameObject ProjectilePrefab => _statValues.projectilePrefab;
        public float Damage => _statValues.damage;
        public int MaxProjectileCount => _statValues.maxProjectileCount;
        public float ShotCooldown => _statValues.shotCooldown;
        public float ReloadCooldown => _statValues.reloadCooldown;
        
        [System.Serializable]
        public struct StatValues
        {
            public GameObject projectilePrefab;
            public float damage;
            public int maxProjectileCount;
            public float shotCooldown;
            public float reloadCooldown;
        }
    }
}