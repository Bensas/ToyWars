using System;
using Strategy;
using Unity.VisualScripting;
using UnityEngine;

namespace Commands
{
    public class CmdLockOn : ICommand
    {
        
        private ILockable _target;
        private IRadar _radar;
        
        public CmdLockOn(IRadar radar, ILockable target)
        {
            _target = target;
            _radar = radar;
        }

        public void Execute()
        {
            if(_radar.Target == _target) return; // Already locked on
            
            if (_radar.IsLocked) // Release
            {
                if(!_radar.Target.IsUnityNull()) // Target is not destroyed
                    _radar.Target.ReleaseLock();
                
                if(_target == null)
                    _radar.ReleaseLock();
            }

            if (_target != null) // Engage
            {
                _radar.LockOnTarget(_target);
                _target.TriggerLock(_radar);
            }
        }
    }
}