using Strategy;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class BaloonMovementController : MonoBehaviour, IMoveableBaloon
    {    
        private Rigidbody _rb;
    
        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public float Speed => 1f;
        public void Move(Vector3 direction)
        {
            _rb.velocity = direction * Speed;
        }
    }
}
