using UnityEngine;

namespace Strategy
{
    public interface IWeapon
    {
        GameObject ProjectilePrefab { get; }
        float Damage { get; }
        int MaxProjectileCount { get; }
        float ShotCooldown { get; }
        float ReloadCooldown { get; }
        
        void Attack();
    }
}