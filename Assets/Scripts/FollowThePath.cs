using System.Collections;
using UnityEngine;

public class FollowThePath : MonoBehaviour {
    
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;
    
    private int waypointIndex = 0;

    private bool isRotating = false;
    private float angleToRotateRemaining = 0f;

    // Use this for initialization
    private void Start ()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }
	
    // Update is called once per frame
    private void Update ()
    {
        Move();
    }
    
    private void Move()
    {
        if (isRotating)
        {
            transform.Rotate(new Vector3(0, 0, -3));
            angleToRotateRemaining -= 3f;

            if (angleToRotateRemaining <= 0f)
                isRotating = false;

            return;
        }
        
        if (waypointIndex >= waypoints.Length)
            waypointIndex = 0;
        
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
            isRotating = true;
            angleToRotateRemaining = 90f;
        }
    }
}