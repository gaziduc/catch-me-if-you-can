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
        if (PauseMenu.isPaused)
            return;
        
        transform.Rotate(new Vector3(0, 0, isGoingLeft ? -speed * Time.deltaTime : speed * Time.deltaTime));

        if (transform.rotation.eulerAngles.z < initialRotationZ + minRotationZ)
            isGoingLeft = false;
        else if (transform.rotation.eulerAngles.z > initialRotationZ + maxRotationZ)
            isGoingLeft = true;
    }
}
