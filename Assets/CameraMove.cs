using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset;
    public float minX = -10f;
    public float maxX = 10f;
    public Vector3 moveLocation;
    private Vector3 velocity = Vector3.zero;




    void LateUpdate()
    {
        if (target != null && !Player.Instance.isAttacking)
        {

            Vector3 targetPosition = target.position + offset;


            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);


            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

        if(Player.Instance.isAttacking)
        {
            Vector3 targetPosition = target.position + offset;


            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);

            Vector3 finalLocation = transform.position;
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(finalLocation.x, finalLocation.y, moveLocation.z), ref velocity, smoothTime);
            


        }


    }
}
