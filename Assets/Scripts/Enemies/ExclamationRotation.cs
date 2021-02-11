using UnityEngine;

public class ExclamationRotation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float z = transform.parent.transform.eulerAngles.z;
        transform.localEulerAngles = new Vector3(0,0, -z);
        
        transform.position = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y + 1.5f, transform.parent.transform.position.z);
    }
}
