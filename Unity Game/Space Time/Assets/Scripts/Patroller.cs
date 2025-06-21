using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] float turnSpeed = 0.9f;
    [SerializeField] float wayPointDistance = 1;
    [SerializeField] Transform[] wayPoints;
    [SerializeField] int wayPointIndex = 0;
    private float gravityValue = 9.81f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get the distance to the next waypoint in the list/array
        float distance = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);

        // If we are close enough to the current waypoint, change to next waypoint
        if(distance < wayPointDistance )
        {
            // increment the index, keeping it in bounds with mod %
            wayPointIndex = (wayPointIndex + 1) % wayPoints.Length;
        }

        // Get the direction to the next waypoint in the list/array
        Vector3 directionToWaypoint = wayPoints[wayPointIndex].position - transform.position;

        // In this case, we are not interested in the height value (y) so zero it
        directionToWaypoint.y = 0;

        // turn and move towards next waypoint
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionToWaypoint), turnSpeed * Time.deltaTime);
        controller.Move(transform.forward * Time.deltaTime * moveSpeed);
        controller.Move(Vector3.down * gravityValue * Time.deltaTime);
    }
}