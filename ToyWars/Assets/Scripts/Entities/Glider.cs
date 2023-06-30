using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using Controllers;
using Controllers.Sound;
using Controllers.LifeControllers;
using Managers;
using Sound;
using Strategy;
using UnityEngine;
using Utils;
using Weapons;
using Flyweight;

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
        private GliderLifeController _gliderLifeController;

        private bool _isShooting = false;

        public Light _gunLight;
        private float gunLightPeriod = 0.1f;

        private bool speedBuffActive = false;
        private float speedBuffActivationTime = 0;
        
        private readonly InputUtils _inputUtils = new();

        public void Start()
        {
            _gliderMovementController = GetComponent<GliderMovementController>();
            _gliderSoundController = GetComponent<GliderSoundController>();
            _gliderRadarController = GetComponent<GliderRadarController>();
            _gliderLifeController = GetComponent<GliderLifeController>();
            Cursor.visible = false;
            
            ChangeWeapon(0);
            EventManager.instance.OnPlayerShoot += OnShot;
            EventManager.instance.OnBaloonKill += ApplyBaloonBuff;
        }

        void Update()
        {
            float roll = -Input.GetAxis("Roll") * _sensitivity;
            float pitch = Input.GetAxis("Pitch") * _sensitivity;
            float yaw = Input.GetAxis("Yaw") * _sensitivity;

            GliderEventQueueManager.instance.AddEvent(new CmdMovement(_gliderMovementController, pitch, yaw, roll));
            
            UpdateLockOnTarget();

            HandleWeaponChange();
            HandleShooting();
            if (speedBuffActive) {
                if (Time.unscaledTime - speedBuffActivationTime > 1.5f) {
                    _gliderMovementController.SetSpeed(2.5f);
                    speedBuffActive = false;
                }
            }
        }

        private void HandleShooting()
        {
            _inputUtils.HandleFireInput();

            if (_inputUtils.OnFiringDown)
            {
                UpdateOnShooting(true);
            }
            else if (_inputUtils.OnFiringUp)
            {
                UpdateOnShooting(false);
            }

            if (_isShooting)
            {
                GliderEventQueueManager.instance.AddEvent(new CmdShoot(_activeWeapon));
                if (!_activeWeapon.FireOnHold)
                {
                    UpdateOnShooting(false);
                }
            }
        }

        private void HandleWeaponChange()
        {
            if (Input.GetButtonDown("Swap"))
            {
                UpdateOnShooting(false);
                ChangeWeapon((_weapons.IndexOf(_activeWeapon) + 1) % _weapons.Count);
            }
        }

        private void ChangeWeapon(int index)
        {
            if (index < 0 || index >= _weapons.Count) return;
            _activeWeapon = _weapons[index];
            _activeWeapon.UpdateAmmoUI();
            _activeWeapon.SetOwnerIsPlayer(true);
            _activeWeapon.SetOwner(this);
            
            EventManager.instance.EventWeaponChange(_activeWeapon);
        }
        
        private void UpdateLockOnTarget()
        {
            var newTarget = _gliderRadarController.GetTargetInView(transform.forward);
            if (_gliderRadarController.Target != newTarget) 
                GliderEventQueueManager.instance.AddEvent(new CmdLockOn(_gliderRadarController, newTarget));

        }

        private void UpdateOnShooting(bool isShooting)
        {
            EventManager.instance.EventShootingUpdate(isShooting, _activeWeapon);
            _isShooting = isShooting;
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

        private void ApplyBaloonBuff(BaloonType type) {
            switch (type){
                case BaloonType.SPEED:
                    speedBuffActive = true;
                    speedBuffActivationTime = Time.unscaledTime;
                    _gliderMovementController.SetSpeed(4f);
                    break;
                case BaloonType.HEALTH:
                    _gliderLifeController.IncreaseLife(200);
                    break;
            }
        }
    }
}