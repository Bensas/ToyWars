using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Managers;
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

        public void Start()
        {
            _gliderMovementController = GetComponent<GliderMovementController>();
            Cursor.visible = false;
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
            }
        }

        private void ChangeWeapon(int index)
        {
            if (index < 0 || index >= _weapons.Count) return;
            _activeWeapon = _weapons[index];
            _activeWeapon.UpdateAmmoUI();
        }
    }
}