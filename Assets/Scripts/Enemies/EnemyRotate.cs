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
    
    private float initialRotationZ;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = initialSpeed;
        
        if (hasBounds)
            initialRotationZ = transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, isGoingLeft ? -speed * Time.deltaTime : speed * Time.deltaTime));

        if (hasBounds)
        {
            if (transform.rotation.eulerAngles.z < initialRotationZ + minRotationZ)
                isGoingLeft = false;
            else if (transform.rotation.eulerAngles.z > initialRotationZ + maxRotationZ)
                isGoingLeft = true;
        }
    }

    public void SetRotationSpeed(float speed)
    {
        this.speed = speed;
    }
}
