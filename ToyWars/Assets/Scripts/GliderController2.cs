using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderController2 : MonoBehaviour
{

    public float sensitivity;

    private float _roll;
    private float _pitch;
    private float _yaw;

    private Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.forward * 1;
        _rb.AddTorque(transform.up * (_yaw * sensitivity));
        _rb.AddTorque(transform.right * (_pitch * sensitivity));
        _rb.AddTorque(transform.forward * (_roll * sensitivity));
    }

    void Update()
    {
        _roll = -Input.GetAxis("Roll");
        _pitch = Input.GetAxis("Pitch");
        _yaw = Input.GetAxis("Yaw");
    }
}
