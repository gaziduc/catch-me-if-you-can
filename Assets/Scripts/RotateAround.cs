using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public float speed;
    public Vector3 axis;
    
    private Vector3 GravityCenter;
    // Start is called before the first frame update
    void Start()
    {
        GravityCenter = transform.GetChild(0).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(GravityCenter, axis, speed * Time.deltaTime);
    }
}
