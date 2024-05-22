using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoint positions
    public float speed = 2f; // Movement speed
    public float turnSpeed = 10f; // Rotation speed

    private int waypointIndex = 0; // Current waypoint index
    private float minDistance = 0.1f; // Minimum distance to consider reached waypoint

    void Start()
    {
        // Initialize position to the first waypoint
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
            RotateTowards(waypoints[waypointIndex]);
        }
        else
        {
            Debug.LogWarning("No waypoints set for " + gameObject.name);
        }
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (waypoints.Length == 0) return; // If no waypoints, do nothing

        // Rotate towards the current waypoint
        RotateTowards(waypoints[waypointIndex]);

        // Move towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);

        // Check if the enemy is within a small distance of the waypoint
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < minDistance)
        {
            // Increment waypoint index, reset if at last waypoint
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0; // Loop back to the first waypoint
                // For a back-and-forth movement instead of looping, you could reverse the waypoints array or implement a direction switch.
            }
            // Rotate towards the next waypoint after incrementing the waypoint index
            RotateTowards(waypoints[waypointIndex]);
        }
    }

    void RotateTowards(Transform targetWaypoint)
    {
        // Get the direction vector from the enemy's position to the target waypoint's position
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        // Calculate the rotation that looks in the direction of the direction vector
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        // Set the enemy's rotation to the calculated rotation
        transform.rotation = lookRotation;
    }
}
