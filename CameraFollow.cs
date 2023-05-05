using UnityEngine;

//FROM BRACKEYS YOUTUBE
public class CameraFollow : MonoBehaviour
{
   public Transform target;

    public float smoothSpeed;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

}
