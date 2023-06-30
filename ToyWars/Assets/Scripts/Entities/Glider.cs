using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using Controllers;
using Controllers.Sound;
using Managers;
using Sound;
using Strategy;
using UnityEngine;
using Utils;
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
        private GliderSoundController _gliderSoundController;
        private GliderRadarController _gliderRadarController;

        private bool _isShooting = false;

        public Light _gunLight;
        private float gunLightPeriod = 0.1f;
        
        private readonly InputUtils _inputUtils = new();

        public void Start()
        {
            _gliderMovementController = GetComponent<GliderMovementController>();
            _gliderSoundController = GetComponent<GliderSoundController>();
            _gliderRadarController = GetComponent<GliderRadarController>();
            Cursor.visible = false;
            
            ChangeWeapon(0);
            EventManager.instance.OnPlayerShoot += OnShot;
        }

        void Update()
        {
            float roll = -Input.GetAxis("Roll") * _sensitivity;
            float pitch = Input.GetAxis("Pitch") * _sensitivity;
            float yaw = Input.GetAxis("Yaw") * _sensitivity;
            
            GliderEventQueueManager.instance.AddEvent(new CmdMovement(_gliderMovementController, pitch, yaw, roll));

            UpdateLockOnTarget();

            HandleShooting();
        }

        private void HandleShooting()
        {
            _inputUtils.HandleFireInput();

            if (_inputUtils.OnFiringDown)
            {
                _isShooting = true;
                EventManager.instance.EventShootingUpdate(true, _activeWeapon);
            }
            else if (_inputUtils.OnFiringUp)
            {
                _isShooting = false;
                EventManager.instance.EventShootingUpdate(false, _activeWeapon);
            }

            if (_isShooting)
            {
                GliderEventQueueManager.instance.AddEvent(new CmdShoot(_activeWeapon));
                if (!_activeWeapon.FireOnHold)
                {
                    EventManager.instance.EventShootingUpdate(false, _activeWeapon);
                    _isShooting = false;
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
        
        private void OnShot(IWeapon weapon)
        {
            StartCoroutine(ToggleLight());
        }
        
        IEnumerator ToggleLight()
        {
            _gunLight.intensity = 8.0f;
             yield return new WaitForSeconds(gunLightPeriod);
             _gunLight.intensity = 0.0f;
        }
    }
}