using Entities;
using Flyweight;
using Managers;
using Strategy;
using UnityEngine;

namespace Weapons
{
    public class MissileLauncher : Weapon
    {
        private IRadar _radar;

        public override void SetOwner(Actor owner)
        {
            base.SetOwner(owner);
            _radar = _owner.GetComponentInChildren<IRadar>();
        }

        protected override GameObject InstantiateProjectile()
        {
            var projectile = Instantiate(ProjectilePrefab, transform.position, transform.rotation);
            projectile.GetComponent<IMissile>().SetOwner(this);
            projectile.GetComponent<IMissile>().SetRadar(_radar);
            return projectile;
        }
    }
}