using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    public float speed;
    private bool isGoingLeft = true;
    private float initialRotationZ;
    public float minRotationZ;
    public float maxRotationZ;
    
    // Start is called before the first frame update
    void Start()
    {
        initialRotationZ = transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoingLeft)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - speed);
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + speed);
        }

        if (transform.rotation.eulerAngles.z < initialRotationZ + minRotationZ)
            isGoingLeft = false;
        else if (transform.rotation.eulerAngles.z > initialRotationZ + maxRotationZ)
            isGoingLeft = true;
    }
}
