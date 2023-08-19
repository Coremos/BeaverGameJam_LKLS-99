using System.Collections.Generic;
using UnityEngine;

public class ItemInstantiator : MonoBehaviour
{
    private List<LocationPoint> locationPoints;

    private void Awake()
    {
        int count = transform.childCount;
        for (int index = 0; index < count; index++)
        {
            var child = transform.GetChild(index);
            if (!child.TryGetComponent(out LocationPoint locationPoint)) continue;
            locationPoints.Add(locationPoint);
        }
    }

    private void InstantiateItems()
    {

    }
}