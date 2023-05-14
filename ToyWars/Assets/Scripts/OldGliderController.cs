using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldGliderController : MonoBehaviour
{

    public float pitchLimits;
    public float yawLimits;

    public float speed = 10f; 
    
    public float liftCoefficient = 0.1f; // Lift coefficient
    public float dragCoefficient = 0.01f; // Drag coefficient
    public float thrust = 1000f; // Thrust force
    public float maxSpeed = 100f; // Maximum speed

    private Rigidbody rb; // Reference to the Rigidbody component
    
    private Vector2 _screenCenter;

    // Start is called before the first frame update
    void Start()
    {
        _screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = (Vector2)Input.mousePosition - _screenCenter;
        offset.x /= _screenCenter.x;
        offset.y /= _screenCenter.y;

        transform.Rotate(offset.y, 0, -offset.x);
        // transform.position += transform.forward * (Time.deltaTime * speed);
    }
    
    void FixedUpdate() {
        // Calculate the forces of lift and drag
        float speed = rb.velocity.magnitude;
        float angleOfAttack = Vector3.Angle(rb.velocity, transform.forward) * Mathf.Deg2Rad;
        Vector3 liftForce = 0.5f * liftCoefficient * speed * speed * angleOfAttack * transform.up;
        Vector3 dragForce = -0.5f * dragCoefficient * speed * speed * rb.velocity.normalized;

        // Apply the forces to the Rigidbody
        rb.AddForce(transform.forward * thrust);
        rb.AddForce(liftForce);
        // rb.AddForce(dragForce);

        // Limit the speed
        if (rb.velocity.magnitude > maxSpeed) {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
