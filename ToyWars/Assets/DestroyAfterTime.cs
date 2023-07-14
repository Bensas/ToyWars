using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    
    [SerializeField] private float secondsToDestroy = 2f;
    void Start()
    {
        Destroy(transform.gameObject, secondsToDestroy);
    }
}
