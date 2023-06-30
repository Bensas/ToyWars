using System;
using Commands;
using Controllers;
using Managers;
using UnityEngine;
using Strategy;
using Flyweight;

namespace Entities
{
    public class Baloon : MonoBehaviour
    {
        // private BaloonMovementController _baloonMovementController;

        public float MAX_HEIGHT = 9;
        public float MIN_HEIGHT = 1;
        public float SPEED = 0.0005f;
        public bool rising = true;
        public float health = 10;

        public BaloonType type = BaloonType.HEALTH;
        
        public void Start()
        {
            // _baloonMovementController = GetComponent<BaloonMovementController>();
            
        }

        void Update()
        {
            transform.Translate(0, rising ? SPEED : -SPEED, 0);
            if (rising && transform.position.y > MAX_HEIGHT)
                    rising = false;
            else if (!rising && transform.position.y < MIN_HEIGHT)
                    rising = true;
            
        }

        // public void TakeDamage(float damage)
        // {
        //     health -= damage;
        //     Debug.Log("Baloon taking damage");
        // }
    }
}