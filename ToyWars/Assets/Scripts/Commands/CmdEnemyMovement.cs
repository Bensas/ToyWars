using Strategy;
using UnityEngine;

namespace Commands
{
    public class CmdEnemyMovement : ICommand
    {
        private IMoveableEnemy _moveable;
        Transform transform;
        Quaternion targetRotation;
        float rotationSpeed;
        float pitchAngle;
        float rollAngle;

        public CmdEnemyMovement(IMoveableEnemy moveable, Transform transform, Quaternion targetRotation, float rotationSpeed, float pitchAngle, float rollAngle)
        {
            this.transform = transform;
            this.targetRotation = targetRotation;
            this.rotationSpeed = rotationSpeed;
            this.pitchAngle = pitchAngle;
            this.rollAngle = rollAngle;
            this._moveable = moveable;
        }
        
        public void Execute() => _moveable.Move(transform, targetRotation, rotationSpeed, pitchAngle, rollAngle);
    }
}