using System.Collections.Generic;
using UnityEngine;

public class ItemInstantiator : MonoBehaviour
{
    [SerializeField] private InteractableItem itemPrefab;
    [SerializeField] private Transform itemRoot;

    private List<LocationPoint> locationPoints;

    private void Awake()
    {
        locationPoints = new List<LocationPoint>();
        int count = transform.childCount;
        for (int index = 0; index < count; index++)
        {
            var child = transform.GetChild(index);
            if (!child.TryGetComponent(out LocationPoint locationPoint)) continue;
            locationPoints.Add(locationPoint);
        }
    }

    private void Start()
    {
        InstantiateItems();
    }

    private void InstantiateItems()
    {
        foreach (var locationPoint in locationPoints)
        {
            var itemObject = Instantiate(itemPrefab);
            itemObject.Item = ItemManager.Instance.ItemTabeDataDic[locationPoint.ItemIndex];
        }
    }
}