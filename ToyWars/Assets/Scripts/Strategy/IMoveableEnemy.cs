using UnityEngine;

namespace Strategy
{
    public interface IMoveableEnemy
    {
        float Speed { get; }
        
        public void Move(Transform transform, Quaternion targetRotation, float rotationSpeed, float pitchAngle, float rollAngle);
    }
}