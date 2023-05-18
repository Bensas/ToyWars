using UnityEngine;

namespace Strategy
{
    public interface IMoveableBaloon
    {
        float Speed { get; }
        
        void Move(Vector3 direction);
    }
}