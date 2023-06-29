using UnityEngine;

namespace Strategy
{
    public interface IRadar
    {
        public void LockOnTarget(ILockable target);
        public void ReleaseLock();
        
        public Vector3 GetPosition();
        
        public bool IsLocked { get; }
        public ILockable Target { get; }
    }
}