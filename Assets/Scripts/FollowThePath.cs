using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    public float moveSpeed = 2f;
    public float rotationSpeed = 200f;
    
    private int waypointIndex = 0;

    private bool isRotating = false;
    private float angleToRotate = 0f;

    // Update is called once per frame
    private void FixedUpdate ()
    {
        Move();
    }
    
    private void Move()
    {
        if (isRotating)
        {
            float angleToRotateMod360 = angleToRotate;
            if (angleToRotateMod360 < 0f)
                angleToRotateMod360 += 360f;
            if (angleToRotateMod360 >= 360f)
                angleToRotateMod360 -= 360f;
            
            if (transform.eulerAngles.z >= angleToRotateMod360 - 10 && transform.eulerAngles.z <= angleToRotateMod360 + 10)
                isRotating = false;
            else
            {
                float angle = rotationSpeed * Time.deltaTime;
            
                if (angleToRotate < transform.eulerAngles.z)
                    angle = -angle;

                transform.Rotate(new Vector3(0, 0, angle));
            }

            return;
        }

        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
            isRotating = true;
            
            if (waypointIndex >= waypoints.Length)
                waypointIndex = 0;
            
            
            Vector3 dir = (waypoints[waypointIndex].transform.position - transform.position).normalized;
            angleToRotate = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (transform.eulerAngles.z - angleToRotate > 180f)
                angleToRotate += 360f;
            else if (transform.eulerAngles.z - angleToRotate < -180f)
                angleToRotate -= 360f;
        }
    }
}