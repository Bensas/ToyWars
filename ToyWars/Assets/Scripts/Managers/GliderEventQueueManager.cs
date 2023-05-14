using System;
using System.Collections.Generic;
using Commands;
using UnityEngine;

namespace Managers
{
    public class GliderEventQueueManager : MonoBehaviour
    {
        public GliderEventQueueManager instance;
        
        public Queue<ICommand> EventQueue => _eventQueue;
        private Queue<ICommand> _eventQueue = new Queue<ICommand>();
        
        private void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
        }
        
        private void Update()
        {
            foreach (var command in _eventQueue)
            {
                command.Execute();
            }

            _eventQueue.Clear();
        }
        
        public void AddEvent(ICommand command) => _eventQueue.Enqueue(command);
    }
}