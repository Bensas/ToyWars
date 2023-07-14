using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Controllers.LifeControllers;
using Managers;
using UnityEngine;
using Weapons;
using Managers;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

namespace Entities
{
    public class Boss : Actor
    {
        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private List<Transform> _waypoints;
        [SerializeField] private float _forwardShootPrediction = 2.5f;

        [SerializeField] private Transform _targetTransform;
        
        private Transform target;

        private static float SHOOT_THRESHOLD = 0.85f;

        public float speed = 100.0f;
        public float rotationSpeed = 2.0f;
        public float maxPitchAngle = 20.0f;
        public float maxRollAngle = 45.0f;

        private float rollAngle;

        private int currentWaypoint = 0;
        
        private BossLifeController _lifeController;

        public void Start()
        {
            target = _targetTransform;
            _lifeController = GetComponent<BossLifeController>();

            GameManager.instance.SetBoss(this);
            EventManager.instance.EventEnemySpawn();
        }

        void Update()
        {
            if(_lifeController.IsDead()) return;
            MoveToWaypoint();
            ShootAllWeapons();
        }

        private void MoveToWaypoint()
        {
            // Get the current waypoint
            var waypoint = _waypoints[currentWaypoint];
            // Get the direction to the waypoint
            var direction = waypoint.position - transform.position;
            // Get the distance to the waypoint
            var distance = direction.magnitude;
            // Normalize the direction
            direction.Normalize();
            // Rotate the boss towards the waypoint
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                rotationSpeed * Time.deltaTime);
            // Move the boss towards the waypoint
            transform.position += transform.forward * (speed * Time.deltaTime);
            // If the boss is close enough to the waypoint, move to the next waypoint
            if (distance < 1.0f)
                currentWaypoint = (currentWaypoint + 1) % _waypoints.Count;
        }

        private void ShootAllWeapons()
        {
            
            var targetPosition = target.position;
            var targetRotation = target.rotation;
            
            // if (!(Mathf.Abs(Quaternion.Dot(transform.rotation, targetRotation)) > SHOOT_THRESHOLD)) return;
            // Debug.Log("shooting");
            foreach (var weapon in _weapons)
            {
                Vector3 predictPosition = targetPosition + target.forward * Random.Range(_forwardShootPrediction * 0.5f, _forwardShootPrediction * 1.5f);
                weapon.transform.LookAt(predictPosition);
                GliderEventQueueManager.instance.AddEvent(new CmdShoot(weapon));
            }
        }
    }
}