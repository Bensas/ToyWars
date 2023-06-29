using UnityEngine;

namespace Strategy
{
    public interface ILockable
    {
        public void TriggerLock(IRadar radar);
        public void ReleaseLock();
        
        public bool IsLocked { get; }
        public bool IsLockable { get; }
        
        public bool IsMyCollider(Collider other);
        
        Vector3 GetPosition();
    }
}