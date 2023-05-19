using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Managers;
using UnityEngine;
using Weapons;
using Managers;

namespace Entities
{
    public class Enemy : Actor
    {

        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private Weapon _activeWeapon; 
        [SerializeField] private float _sensitivity = 15f;

        public Transform target;

         private static float SHOOT_THRESHOLD = 0.85f;

         public float speed = 100.0f;
          public float rotationSpeed = 2.0f;
          public float maxPitchAngle = 20.0f;
          public float maxRollAngle = 45.0f;
          public float altitudeChangeThreshold = 50.0f;
          private float altitude;
          private float pitchAngle;
        
        private float rollAngle;
        
        private EnemyMovementController _enemyMovementController;

        public void Start()
        {
            _enemyMovementController = GetComponent<EnemyMovementController>();
            Cursor.visible = false;
        }

        void Update()
        {
            
            // GliderEventQueueManager.instance.AddEvent(new CmdEnemyMovement(_enemyMovementController, pitch, yaw, roll));

            if (Input.GetAxisRaw("Fire1") > 0)
            {
                GliderEventQueueManager.instance.AddEvent(new CmdShoot(_activeWeapon));
            }
            
             // Get the target position and direction
            var targetPosition = target.position;
            var targetDirection = targetPosition - transform.position;

            // Rotate the plane towards the target
            var targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);


            // Calculate pitch angle based on the difference in altitude
            var targetAltitude = targetPosition.y;
            var altitudeDifference = targetAltitude - altitude;
            pitchAngle = Mathf.Clamp(altitudeDifference / altitudeChangeThreshold, -maxPitchAngle, maxPitchAngle);

            // Calculate roll angle based on the direction to the target
            var localTarget = transform.InverseTransformPoint(targetPosition);
            rollAngle = Mathf.Clamp(localTarget.x / localTarget.magnitude, -maxRollAngle, maxRollAngle);

            // Update the altitude
            altitude = targetAltitude;

            // Apply the rotation and movement
            GliderEventQueueManager.instance.AddEvent(new CmdEnemyMovement(_enemyMovementController, transform, targetRotation, rotationSpeed, pitchAngle, rollAngle));

            if (Mathf.Abs(Quaternion.Dot(transform.rotation, targetRotation)) > SHOOT_THRESHOLD) {
                GliderEventQueueManager.instance.AddEvent(new CmdShoot(_activeWeapon));
            }

        }

        private void ChangeWeapon(int index)
        {
            if (index < 0 || index >= _weapons.Count) return;
            _activeWeapon = _weapons[index];
        }
    }
}