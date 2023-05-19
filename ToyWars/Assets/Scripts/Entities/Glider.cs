using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Managers;
using Sound;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Glider : Actor
    {

        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private Weapon _activeWeapon; 
        [SerializeField] private float _sensitivity = 15f;
        
        private GliderMovementController _gliderMovementController;
        private GliderSoundController _gliderSoundController;

        private bool _isShooting = false;

        public void Start()
        {
            _gliderMovementController = GetComponent<GliderMovementController>();
            _gliderSoundController = GetComponent<GliderSoundController>();
            Cursor.visible = false;
            
            ChangeWeapon(0);
        }

        void Update()
        {
            float roll = -Input.GetAxis("Roll") * _sensitivity;
            float pitch = Input.GetAxis("Pitch") * _sensitivity;
            float yaw = Input.GetAxis("Yaw") * _sensitivity;
            
            GliderEventQueueManager.instance.AddEvent(new CmdMovement(_gliderMovementController, pitch, yaw, roll));

            if (Input.GetAxisRaw("Fire1") > 0)
            {
                GliderEventQueueManager.instance.AddEvent(new CmdShoot(_activeWeapon));
                if (!_isShooting)
                {
                    _isShooting = true;
                    EventManager.instance.EventShootingUpdate(true);
                }
            }
            else
            {
                if(_isShooting)
                {
                    _isShooting = false;
                    EventManager.instance.EventShootingUpdate(false);
                }
            }
        }

        private void ChangeWeapon(int index)
        {
            if (index < 0 || index >= _weapons.Count) return;
            _activeWeapon = _weapons[index];
            _activeWeapon.UpdateAmmoUI();
            _activeWeapon.SetOwnerIsPlayer(true);
        }
    }
}