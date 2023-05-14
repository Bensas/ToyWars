using Strategy;

namespace Commands
{
    public class CmdMovement : ICommand
    {
        private IMoveable _moveable;
        private float _pitch;
        private float _yaw;
        private float _roll;
        
        public CmdMovement(IMoveable moveable, float pitch, float yaw, float roll)
        {
            _moveable = moveable;
            _pitch = pitch;
            _yaw = yaw;
            _roll = roll;
        }
        
        public void Execute() => _moveable.Move(_pitch, _yaw, _roll);
    }
}