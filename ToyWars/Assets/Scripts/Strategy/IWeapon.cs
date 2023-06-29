using Entities;
using Flyweight;
using UnityEngine;

namespace Strategy
{
    public interface IWeapon
    {
        
        public void SetOwner(Actor owner);
        GameObject ProjectilePrefab { get; }
        float Damage { get; }
        int MaxProjectileCount { get; }
        float ShotCooldown { get; }
        float ReloadCooldown { get; }
        AudioClip ShotSound { get; }
        bool FireOnHold { get; }
        
        void Attack();
    }
}