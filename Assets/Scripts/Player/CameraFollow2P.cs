using UnityEngine;


public class CameraFollow2P : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    
    public Vector2 minPosition;
    public Vector2 maxPosition;
    
    // How many units should we keep from the players
    public float zoomFactor = 1.6f;
    public float followTimeDelta = 0.8f;

    private float initialSize;

    private void Start()
    {
        initialSize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        FixedCameraFollowSmooth(Camera.main, player1, player2);
    }
    
    // Follow Two Transforms with a Fixed-Orientation Camera
    private void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        // Midpoint we're after
        Vector3 midpoint = (t1.position + t2.position) / 2f;

        // Distance between objects
        Vector2 distance = t1.position - t2.position;
        if (distance.x < 0)
            distance.x = -distance.x;
        if (distance.y < 0)
            distance.y = -distance.y;

        // Move camera a certain distance
        Vector3 cameraDestination = new Vector3(midpoint.x, midpoint.y, cam.transform.position.z);

        // Adjust ortho size if we're using one of those
        if (cam.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            cam.orthographicSize = distance.y / 2 * zoomFactor;
            
            float xSize = distance.x * Screen.height / Screen.width;
            if (xSize > distance.y)
                cam.orthographicSize = xSize / 2 * zoomFactor;
            
            if (cam.orthographicSize < initialSize)
                cam.orthographicSize = initialSize;
        }

        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);
        
        // Slerp Bug Fix (camera changing in Z pos)
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
        
        
        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = cameraDestination;
        
        float horzExtent = cam.orthographicSize * Screen.width / Screen.height;


        if (IsOutboundLeft(cam, horzExtent) && IsOutboundRight(cam, horzExtent) ||
            IsOutboundUp(cam) && IsOutboundDown(cam))
        {
            cam.transform.position = new Vector3((maxPosition.x + minPosition.x) / 2,
                (maxPosition.y + minPosition.y) / 2, cam.transform.position.z);
            cam.orthographicSize = (maxPosition.y - minPosition.y) / 2;
        }
        else
        {
            if (IsOutboundLeft(cam, horzExtent))
                cam.transform.position = new Vector3(minPosition.x + horzExtent, cam.transform.position.y, cam.transform.position.z);

            else if (IsOutboundRight(cam, horzExtent))
                cam.transform.position = new Vector3(maxPosition.x - horzExtent, cam.transform.position.y, cam.transform.position.z);

            if (IsOutboundUp(cam))
                cam.transform.position = new Vector3(cam.transform.position.x, minPosition.y + cam.orthographicSize, cam.transform.position.z);

            else if (IsOutboundDown(cam))
                cam.transform.position = new Vector3(cam.transform.position.x, maxPosition.y - cam.orthographicSize, cam.transform.position.z);
        }
    }

    private bool IsOutboundLeft(Camera cam, float horzExtent)
    {
        return cam.transform.position.x - horzExtent < minPosition.x;
    }
    
    private bool IsOutboundRight(Camera cam, float horzExtent)
    {
        return cam.transform.position.x + horzExtent > maxPosition.x;
    }
    
    private bool IsOutboundUp(Camera cam)
    {
        return cam.transform.position.y - cam.orthographicSize < minPosition.y;
    }
    
    private bool IsOutboundDown(Camera cam)
    {
        return cam.transform.position.y + cam.orthographicSize > maxPosition.y;
    }
}
