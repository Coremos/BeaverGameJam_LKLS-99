using UnityEngine;

public class JoyStick : MonoBehaviour
{
    [SerializeField] private float range;
    private IMovementController controller;
    private Vector3 originPosition;

    private void Awake()
    {
        originPosition = transform.position;
    }

    private void FixedUpdate()
    {
        int touchCount = Input.touchCount;
        if (touchCount == 0) return;

        for (int index = 0; index < touchCount; index++)
        {
            var touch = Input.GetTouch(index);

        }

        var deltaPosition = transform.position - originPosition;
        var normalized = deltaPosition.normalized;
        controller.Move(normalized);
    }
}
