using Strategy;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class GliderMovementController : MonoBehaviour, IMoveable
    {
        [SerializeField] private float _speed = 500f;
        private Rigidbody _rb;
        
        public float Speed => _speed;
    
        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        
        public void Move(float pitch, float yaw, float roll)
        {
            _rb.velocity = transform.forward * (Speed * Time.deltaTime);
            _rb.AddTorque(transform.up * (yaw * Time.deltaTime));
            _rb.AddTorque(transform.right * (pitch * Time.deltaTime));
            _rb.AddTorque(transform.forward * (roll * Time.deltaTime));
        }
    }
}
