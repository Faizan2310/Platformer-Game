using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public float rotationSpeed; // Rotation speed in degrees per second

    // Update is called once per frame
    void Update()
    {
        // Rotate around the Y-axis at rotationSpeed degrees per second
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
