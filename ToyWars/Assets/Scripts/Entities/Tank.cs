using System;
using Commands;
using Controllers;
using Managers;
using UnityEngine;
using Strategy;
using Flyweight;

namespace Entities
{
    public class Tank : MonoBehaviour
    {
        public GameObject explosionPrefab;
        
        public void Start()
        {
          EventManager.instance.OnBombExplode += DieIfInsideBombRadius;
        }

        void Update()
        {

        }

        void Die()
        {
          var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
          EventManager.instance.EventTankKill();
          Destroy(this.gameObject);
        }

        void DieIfInsideBombRadius(Vector3 bombPosition, float explosionRadius)
        {
          Debug.Log("Checking if tank is inside bomb radius" + bombPosition + explosionRadius);

          if (Vector3.Distance(bombPosition, transform.position) < explosionRadius)
          {
            Debug.Log("Bomb hit tank");
            Die();
          }
        }

    }
}