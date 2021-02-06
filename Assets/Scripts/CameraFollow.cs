using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector2 minPosition;
    public Vector2 maxPosition;
    
    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x),
                                                        Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y),
                                                        Camera.main.transform.position.z);
    }
}
