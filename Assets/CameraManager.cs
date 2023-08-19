using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Vector2 minPosition;
    [SerializeField] private Vector2 maxPosition;
    private Vector3 bufferVector;

    private void FixedUpdate()
    {
        bufferVector = transform.position;
        if (bufferVector.x < minPosition.x)
        {
            bufferVector.x = minPosition.x;
        }
        if (bufferVector.y < minPosition.y)
        {
            bufferVector.y = minPosition.y;
        }

    }
}
