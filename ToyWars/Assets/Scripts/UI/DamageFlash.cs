using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (image.color.a > 0) {
            Color newCol = image.color;
            newCol.a -= 0.02f;
            image.color = newCol;
        }
    }
}
