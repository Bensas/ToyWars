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

        public Material speedMaterial;
        public Material healthMaterial;

        public BaloonType type = BaloonType.HEALTH;
        private Material globeMaterial;
        
        public void Start()
        {
            // _baloonMovementController = GetComponent<BaloonMovementController>();
            type = UnityEngine.Random.value > 0.5 ? BaloonType.HEALTH : BaloonType.SPEED;

            // globeMaterial = ;
            switch (type) {
                case BaloonType.HEALTH:
                    transform.Find("Loft01").GetComponent<Renderer>().material = healthMaterial;
                    break;
                case BaloonType.SPEED:
                    transform.Find("Loft01").GetComponent<Renderer>().material = speedMaterial;
                    break;
            }
            
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