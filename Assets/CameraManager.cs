using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 minPosition;
    [SerializeField] private Vector2 maxPosition;
    [SerializeField] private Transform target;
    private Vector3 tempVector;

    private void FixedUpdate()
    {
        tempVector = Vector2.Lerp(transform.position, target.position, speed * Time.deltaTime);
        if (tempVector.x < minPosition.x)
        {
            tempVector.x = minPosition.x;
        }
        else if (tempVector.x > maxPosition.x)
        {
            tempVector.x = maxPosition.x;
        }
        if (tempVector.y < minPosition.y)
        {
            tempVector.y = minPosition.y;
        }
        else if (tempVector.y > maxPosition.y)
        {
            tempVector.y = maxPosition.y;
        }
        tempVector.z = -10.0f;
        transform.position = tempVector;
    }
}