using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float smoothTime = 0.3f; 
    public Vector3 offset; 
    public float minX = -10f; 
    public float maxX = 10f; 
    private Vector3 velocity = Vector3.zero;


  

    void LateUpdate()
    {
        if (target != null)
        {
           
            Vector3 targetPosition = target.position + offset;

           
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);

            
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
