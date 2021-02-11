using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector2 minPosition;
    public Vector2 maxPosition;

    private Vector2 velocity;

    public float smoothTime;
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(Camera.main.transform.position.x, transform.position.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(Camera.main.transform.position.y, transform.position.y, ref velocity.y, smoothTime);
        
        Camera.main.transform.position = new Vector3(Mathf.Clamp(posX, minPosition.x, maxPosition.x),
                                                        Mathf.Clamp(posY, minPosition.y, maxPosition.y),
                                                        Camera.main.transform.position.z);
    }
}
