using System;
using Strategy;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class EnemyLockController : MonoBehaviour, ILockable
    {
        [SerializeField] private GameObject _lockUI;
        private IRadar _lockedBy;
        
        public bool IsLocked => _lockedBy != null;
        public bool IsLockable => true;

        public Vector3 GetPosition() => transform.position;

        public void TriggerLock(IRadar radar)
        {
            _lockUI.SetActive(true);
            _lockedBy = radar;
        }

        public void ReleaseLock()
        {
            _lockUI.SetActive(false);
            _lockedBy = null;
        }
        
        public bool IsMyCollider(Collider other)
        {
            return other.gameObject == gameObject;
        }
        
        private void Update()
        {
            if (IsLocked)
            {
                _lockUI.transform.LookAt(_lockedBy.GetPosition());
            }
        }
    }
}
