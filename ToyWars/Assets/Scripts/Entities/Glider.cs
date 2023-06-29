using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Managers;
using Sound;
using Strategy;
using UnityEngine;
using Weapons;

namespace Entities
{
    [RequireComponent(typeof(GliderMovementController))]
    [RequireComponent(typeof(GliderRadarController))]
    public class Glider : Actor
    {

        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private Weapon _activeWeapon;
        [SerializeField] private float _sensitivity = 15f;
        [SerializeField] private float maxTargetDistance = 50f; 
        
        private GliderMovementController _gliderMovementController;
        private GliderRadarController _gliderRadarController;

        private bool _isShooting = false;

        public void Start()
        {
            _gliderMovementController = GetComponent<GliderMovementController>();
            _gliderRadarController = GetComponent<GliderRadarController>();
            
            Cursor.visible = false;
            
            ChangeWeapon(0);
        }

        void Update()
        {
            float roll = -Input.GetAxis("Roll") * _sensitivity;
            float pitch = Input.GetAxis("Pitch") * _sensitivity;
            float yaw = Input.GetAxis("Yaw") * _sensitivity;
            
            GliderEventQueueManager.instance.AddEvent(new CmdMovement(_gliderMovementController, pitch, yaw, roll));

            UpdateLockOnTarget();
            
            if (Input.GetAxisRaw("Fire1") > 0)
            {
                if (!_isShooting)
                {
                    _isShooting = true;
                    EventManager.instance.EventShootingUpdate(true, _activeWeapon);
                    GliderEventQueueManager.instance.AddEvent(new CmdShoot(_activeWeapon));
                }
                else
                {
                    if(_activeWeapon.FireOnHold)
                        GliderEventQueueManager.instance.AddEvent(new CmdShoot(_activeWeapon));
                }
            }
            else
            {
                if(_isShooting)
                {
                    _isShooting = false;
                    EventManager.instance.EventShootingUpdate(false, _activeWeapon);
                }
            }
        }

        private void ChangeWeapon(int index)
        {
            if (index < 0 || index >= _weapons.Count) return;
            _activeWeapon = _weapons[index];
            _activeWeapon.UpdateAmmoUI();
            _activeWeapon.SetOwnerIsPlayer(true);
            _activeWeapon.SetOwner(this);
        }
        
        private void UpdateLockOnTarget()
        {
            var newTarget = _gliderRadarController.GetTargetInView(transform.forward);
            if (_gliderRadarController.Target != newTarget) 
                GliderEventQueueManager.instance.AddEvent(new CmdLockOn(_gliderRadarController, newTarget));

        }
    }
}