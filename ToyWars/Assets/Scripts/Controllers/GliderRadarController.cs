using System.Collections.Generic;
using System.Linq;
using Strategy;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(SphereCollider))]
    public class GliderRadarController : MonoBehaviour, IRadar
    {
        
        [SerializeField] private float _viewAngle = 25f;
        [SerializeField] private float _maxDistance = 50f;
        
        private readonly HashSet<ILockable> _targetsInRange = new();

        public void LockOnTarget(ILockable target) => Target = target;
        public void ReleaseLock() => Target = null;
        public Vector3 GetPosition() => transform.position;

        public bool IsLocked => Target != null;
        public ILockable Target { get; private set; }
        
        public ILockable GetTargetInView(Vector3 forward)
        {
            _targetsInRange.RemoveWhere(tar => tar.IsUnityNull()); // Remove destroyed targets.

            var targetsInView = _targetsInRange
                .Where(target => target.IsLockable)
                .Where(target => Vector3.Angle(forward, target.GetPosition() - this.GetPosition()) < _viewAngle)
                .OrderBy(target => Vector3.Angle(forward, target.GetPosition() - this.GetPosition()));
        
        foreach (ILockable target in targetsInView)
        {
            Ray ray = new Ray(this.GetPosition(), forward);
            
            if (Physics.Raycast(ray, out var hit, _maxDistance,  LayerMask.GetMask("Projectile")))
                if(!target.IsMyCollider(hit.collider)) continue; // Target is behind something else. Skip.

            return target;
        }
        
            return null; // No targets in view.
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponent<ILockable>();
            if (target != null) _targetsInRange.Add(target);
        }
        
        private void OnTriggerExit(Collider other)
        {
            var target = other.GetComponent<ILockable>();
            if (target != null) _targetsInRange.Remove(target);
        }
    }
}