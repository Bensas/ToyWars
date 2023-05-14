using System;
using Commands;
using Controllers;
using Managers;
using UnityEngine;

namespace Entities
{
    public class Glider : MonoBehaviour
    {
        private GliderMovementController _gliderMovementController;

        public void Start()
        {
            _gliderMovementController = GetComponent<GliderMovementController>();
            
        }

        void Update()
        {
            float _roll = -Input.GetAxis("Roll");
            float _pitch = Input.GetAxis("Pitch");
            float _yaw = Input.GetAxis("Yaw");
            
            if(Mathf.Abs(_roll) > 0.0001f || Mathf.Abs(_pitch) > 0.0001f || Mathf.Abs(_yaw) > 0.0001f)
                GliderEventQueueManager.instance.AddEvent(new CmdMovement(_gliderMovementController, _pitch, _yaw, _roll));

        }
    }
}