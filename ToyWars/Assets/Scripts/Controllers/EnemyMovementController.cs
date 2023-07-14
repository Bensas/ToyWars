using Strategy;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyMovementController : MonoBehaviour, IMoveableEnemy
    {    
        private Rigidbody _rb;
        public float SPEED = 100f;
    
        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public float Speed => 1f;
        public void Move(Transform transform, Quaternion targetRotation, float rotationSpeed, float pitchAngle, float rollAngle)
        {   
            if (transform == null) return;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            // transform.Rotate(pitchAngle, 0, -rollAngle);
            transform.Translate(Vector3.forward * (SPEED * Time.deltaTime));
        }
    }
}
