using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem parts = transform.Find("Exposion-[Explosion1]").GetComponent<ParticleSystem>();
        float totalDuration = parts.duration + parts.startLifetime;
        Destroy(this, totalDuration);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
