using System;
using Commands;
using Controllers;
using Managers;
using UnityEngine;

namespace Entities
{
    public class Baloon : MonoBehaviour
    {
        private BaloonMovementController _baloonMovementController;

        public float MAX_HEIGHT = 9;
        public float MIN_HEIGHT = 1;
        public bool rising = true;
        
        public void Start()
        {
            _baloonMovementController = GetComponent<BaloonMovementController>();
            
        }

        void Update()
        {
            Vector3 movementDirection = new Vector3(0, rising ? 1 : -1, 0);
            if (rising && transform.position.y > MAX_HEIGHT)
                    rising = false;
            else if (!rising && transform.position.y < MIN_HEIGHT)
                    rising = true;
            GliderEventQueueManager.instance.AddEvent(new CmdBaloonMovement(_baloonMovementController, movementDirection));
        }
    }
}