namespace Strategy
{
    public interface IMoveable
    {
        float Speed { get; }
        
        void Move(float pitch, float yaw, float roll);
    }
}