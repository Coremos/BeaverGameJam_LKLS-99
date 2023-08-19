using UnityEngine;

public class InteractionIndicator : MonoBehaviour
{
    private const int raycastBufferCount = 10;
    private RaycastHit2D[] raycastBuffer;
    private Transform target;
    private bool isActivated;

    [SerializeField] private float interactionRange;
    [SerializeField] private InteractableObjectIndicator indicator;

    private void Awake()
    {
        raycastBuffer = new RaycastHit2D[raycastBufferCount];
    }

    private void Update()
    {
        if (target == null) return;
        indicator.transform.position = Vector3.Lerp(indicator.transform.position, Camera.main.WorldToScreenPoint(target.position), 10.0f * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        var count = Physics2D.CircleCastNonAlloc(transform.position, interactionRange, Vector2.zero, raycastBuffer);

        if (count == 0)
        {
            indicator.SetActive(false);
            isActivated = false;
            indicator.InteractableObject = null;
            return;
        }
        if (count > raycastBufferCount)
        {
            Debug.LogError("RaycastBufferOverFlow");
            return;
        }
        target = GetNearestObjectTransform(count);
        if (target == null)
        {
            indicator.SetActive(false);
            isActivated = false;
            indicator.InteractableObject = null;
            return;
        }
        if (!isActivated)
        {
            isActivated = true;
            indicator.transform.position = Camera.main.WorldToScreenPoint(target.position);
        }
        target.TryGetComponent(out indicator.InteractableObject);
        indicator.SetActive(true);
    }

    private Transform GetNearestObjectTransform(int count)
    {
        Transform nearestTransform = null;
        float shortestDistance = float.MaxValue;
        for (int index = 0; index < count; index++)
        {
            if (raycastBuffer[index].collider == null) continue;
            if (!raycastBuffer[index].transform.TryGetComponent(out IInteractableObject interactable)) continue;
            if (raycastBuffer[index].transform == transform) continue;
            var difference = raycastBuffer[index].transform.position - transform.position;
            var distance = difference.x * difference.x + difference.y * difference.y;
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestTransform = raycastBuffer[index].transform;
            }
        }
        return nearestTransform;
    }
}