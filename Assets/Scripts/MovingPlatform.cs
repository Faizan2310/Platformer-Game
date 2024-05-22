using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
   [SerializeField] private float speed = 2.0f;

    private Vector3 targetPosition;

    void Start()
    {
        transform.position = pointA.position;
        targetPosition = pointB.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < .1f)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

}
