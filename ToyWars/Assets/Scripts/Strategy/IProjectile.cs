using UnityEngine;

namespace Strategy
{
    public interface IProjectile
    {
        IWeapon Owner { get; }
        float Damage { get; }
        float LifeTime { get; }
        float Speed { get; }

        void Travel();
        void OnCollisionEnter(Collision collision);
        void SetOwner(IWeapon owner);
    }
}