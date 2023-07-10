using System;
using Commands;
using Flyweight;
using Managers;
using Strategy;
using UnityEngine;

namespace Entities
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private BombStats _stats;

        public GameObject floor;

        public float EXPLOSION_RADIUS = 3.0f;

        public float Damage => _stats.Damage;
        public float Speed => _stats.Speed;

        [SerializeField] private float _currentLifetime;

        private void Start()
        {

            floor = GameObject.Find("Floor");
            
        }
        
        public void Travel() => transform.Translate( 0, -Speed * Time.deltaTime, 0);

        public void OnHitFloor()
        {
            EventManager.instance.EventBombExplode(transform.position, EXPLOSION_RADIUS);
            
            Destroy(this.gameObject);
        }

        void Update()
        {
            Travel();
            if (transform.position.y <= floor.transform.position.y)
            {
                OnHitFloor();
            }
        }
    }
}