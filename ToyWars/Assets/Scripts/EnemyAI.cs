// using UnityEngine;

// public class EnemyAI : MonoBehaviour, IShooter
// {
//     public float speed = 100.0f;
//     public float rotationSpeed = 2.0f;
//     public float maxPitchAngle = 20.0f;
//     public float maxRollAngle = 45.0f;
//     public float altitudeChangeThreshold = 50.0f;
//     private float altitude;
//     private float pitchAngle;

//     private float rollAngle;

//     private static float SHOOT_THRESHOLD = 0.85f;

//     public Transform target;

//     [SerializeField] private Weapon _activeWeapon; 

//     private void Start()
//     {
//     }

//     private void Update()
//     {
//         // Get the target position and direction
//         var targetPosition = target.position;
//         var targetDirection = targetPosition - transform.position;

//         // Rotate the plane towards the target
//         var targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

//         // Calculate pitch angle based on the difference in altitude
//         var targetAltitude = targetPosition.y;
//         var altitudeDifference = targetAltitude - altitude;
//         pitchAngle = Mathf.Clamp(altitudeDifference / altitudeChangeThreshold, -maxPitchAngle, maxPitchAngle);

//         // Calculate roll angle based on the direction to the target
//         var localTarget = transform.InverseTransformPoint(targetPosition);
//         rollAngle = Mathf.Clamp(localTarget.x / localTarget.magnitude, -maxRollAngle, maxRollAngle);

//         // Update the altitude
//         altitude = targetAltitude;

//         // Apply the rotation and movement
//         GliderEventQueueManager.instance.AddEvent(new CmdMovement(_gliderMovementController, pitch, yaw, roll));

//         if (Mathf.Abs(Quaternion.Dot(transform.rotation, targetRotation)) > SHOOT_THRESHOLD) {
//             GliderEventQueueManager.instance.AddEvent(new CmdShoot(_activeWeapon));
//         }
//     }

//     private void Shoot()
//     {

//     }

// }