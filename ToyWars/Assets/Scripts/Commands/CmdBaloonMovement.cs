using Strategy;
using UnityEngine;

namespace Commands
{
    public class CmdBaloonMovement : ICommand
    {
        private IMoveableBaloon _moveable;
        private Vector3 _direction;
        
        public CmdBaloonMovement(IMoveableBaloon moveable, Vector3 direction)
        {
            _moveable = moveable;
            _direction = direction;
        }
        
        public void Execute() => _moveable.Move(_direction);
    }
}