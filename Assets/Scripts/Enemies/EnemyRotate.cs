using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    public float initialSpeed;
    public bool isGoingLeft = true;
    public float minRotationZ;
    public float maxRotationZ;
    public bool hasBounds = true;
    
    private float currentRotationZ;
    private float speed;

    private FollowThePath followThePath;

    // Start is called before the first frame update
    void Start()
    {
        speed = initialSpeed;
        
        if (hasBounds)
            currentRotationZ = transform.rotation.eulerAngles.z;

        followThePath = GetComponent<FollowThePath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!followThePath || !followThePath.isRotating)
        {
            transform.Rotate(new Vector3(0, 0, isGoingLeft ? -speed * Time.deltaTime : speed * Time.deltaTime));
            
            if (hasBounds)
            {
                float boundLeftMod360 = currentRotationZ + maxRotationZ;
                float boundRightMod360 = currentRotationZ + minRotationZ;
                
                if (Mathf.DeltaAngle(currentRotationZ, transform.rotation.eulerAngles.z) < minRotationZ)
                    isGoingLeft = false;
                else if (Mathf.DeltaAngle(currentRotationZ, transform.rotation.eulerAngles.z) > maxRotationZ)
                    isGoingLeft = true;
            }
        }
    }

    public void SetRotationSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetCurrentRotationZ(float currentRotationZ)
    {
        this.currentRotationZ = currentRotationZ;
    }
}
