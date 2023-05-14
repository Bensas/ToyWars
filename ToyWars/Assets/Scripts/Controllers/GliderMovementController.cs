using Strategy;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class GliderMovementController : MonoBehaviour, IMoveable
    {
        public float sensitivity;
    
        private Rigidbody _rb;
    
        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public float Speed => 1;
        public void Move(float pitch, float yaw, float roll)
        {
            _rb.velocity = transform.forward * Speed;
            _rb.AddTorque(transform.up * (yaw * sensitivity));
            _rb.AddTorque(transform.right * (pitch * sensitivity));
            _rb.AddTorque(transform.forward * (roll * sensitivity));
        }
    }
}
