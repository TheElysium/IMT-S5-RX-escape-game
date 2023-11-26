using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField]
    private Waypoints waypoints;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]

    private float distanceTreshold = .1f;

    private Transform currentWaypoint;

    private bool isMovementEnded = false;

    public delegate void MovementEnded();
    public event MovementEnded OnMovementEnded;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovementEnded) return;

        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceTreshold)
        {
            Transform nextWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            if (nextWaypoint == currentWaypoint)
            {
                isMovementEnded = true;
                OnMovementEnded?.Invoke();
            }
            else
            {
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                transform.LookAt(currentWaypoint);
            }
        }
    }
}
