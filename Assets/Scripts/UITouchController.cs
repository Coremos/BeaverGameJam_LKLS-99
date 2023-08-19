using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EventSystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening.Plugins;
using System.ComponentModel;

public class UITouchController : MonoBehaviour
{
    public GraphicRaycaster GraphicRaycaster;

    public GameObject MoveTargetObject;

    private PointerEventData PointerEventData;

    private bool _isDrag = false;
    private ItemData _itemData = null;
    private InventoryItemComponent _targetComponent = null;


    private void Awake()
    {
        PointerEventData = new PointerEventData(null);
    }

    // Update is called once per frame
    void Update()
    {
        PointerEventData.position = Input.mousePosition;
        List<RaycastResult> raycastResult = new List<RaycastResult>();
        GraphicRaycaster.Raycast(PointerEventData, raycastResult);

        if (raycastResult.Count <= 0)
        {
            return;
        }

        // 이벤트 처리부분
        OnPointerDown(raycastResult);
        OnPointerDrag();
        OnPointerUp(raycastResult);
    }

    private void OnPointerDown(List<RaycastResult> raycastResults)
    {
        if (_isDrag)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) == false)
        {
            return;
        }

        for (int i = 0; i < raycastResults.Count; i++)
        {
            var component = raycastResults[i].gameObject.GetComponent<InventoryItemComponent>();
            if (component != null)
            {
                _targetComponent = component;
                _isDrag = true;
                MoveTargetObject.SetActive(true);
                return;
            }
        }
    }

    private void OnPointerDrag()
    {
        if (_isDrag == false || _targetComponent == null)
        {
            return;
        }

        if (Input.GetMouseButton(0) == false)
        {
            return;
        }


        MoveTargetObject.transform.position = PointerEventData.position;
    }

    private void OnPointerUp(List<RaycastResult> raycastResults)
    {
        if (_isDrag == false || _targetComponent == null)
        {
            return;
        }

        if (Input.GetMouseButtonUp(0) == false)
        {
            return;
        }

        for (int i = 0; i < raycastResults.Count; i++)
        {
            var converter = raycastResults[i].gameObject.GetComponent<ItemConverterComponent>();
            if (converter != null)
            {
                converter.AddItem(_targetComponent.ItemData);
            }
        }

        _targetComponent = null;
        _isDrag = false;
        MoveTargetObject.SetActive(false);
    }
}
