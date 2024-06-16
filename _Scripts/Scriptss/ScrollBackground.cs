using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed = -2f;
    public float lowerYValeu = -18f;
    public float upperYValue = 36f;
    private void Update()
    {
        transform.Translate(0f, this.speed * Time.deltaTime, 0f);
        if (transform.position.y <= lowerYValeu)
        {
            transform.Translate(0f, upperYValue, 0f);
        }
    }
}
