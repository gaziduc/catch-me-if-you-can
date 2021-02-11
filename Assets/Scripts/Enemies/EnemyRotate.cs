using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    public float speed;
    public bool isGoingLeft = true;
    public float minRotationZ;
    public float maxRotationZ;
    public bool hasBounds = true;
    
    private float initialRotationZ;

    // Start is called before the first frame update
    void Start()
    {
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
}
