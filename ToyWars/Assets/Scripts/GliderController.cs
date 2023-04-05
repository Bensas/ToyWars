using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderController : MonoBehaviour
{

    public float pitchLimits;
    public float yawLimits;

    public float speed = 10f; 
    
    private Vector2 _screenCenter;

    // Start is called before the first frame update
    void Start()
    {
        _screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = (Vector2)Input.mousePosition - _screenCenter;
        offset.x /= _screenCenter.x;
        offset.y /= _screenCenter.y;

        transform.Rotate(offset.y, 0, -offset.x);
        transform.position += transform.forward * (Time.deltaTime * speed);
    }
}
