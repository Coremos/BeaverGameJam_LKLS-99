using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UITouchController : MonoBehaviour
{
    public GraphicRaycaster GraphicRaycaster;

    public GameObject MoveTargetObject;

    private PointerEventData PointerEventData;

    private bool _isDrag = false;
    private ItemData _itemData = null;
    private ItemComponent _targetComponent = null;
    private Transform _defaultParentTransform = null;


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
            var component = raycastResults[i].gameObject.GetComponent<ItemComponent>();
            if (component == null)
            {
                continue;
            }

            if (component.isMoveableType() == false)
            {
                continue;
            }

            _targetComponent = component;
            _defaultParentTransform = component.transform.parent;
            _targetComponent.transform.parent = MoveTargetObject.transform;
            _isDrag = true;
            return;
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

        _targetComponent.transform.position = PointerEventData.position;
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

        var isMoved = false;
        for (int i = 0; i < raycastResults.Count; i++)
        {
            var itemBox = raycastResults[i].gameObject.GetComponent<ItemBox>();
            if (itemBox != null)
            {
                bool isVaild = itemBox.AddItem(_targetComponent);
                if (isVaild == false)
                {
                    continue;
                }

                _targetComponent.transform.parent = itemBox.content;
                isMoved = true;
                break;
            }
        }

        if (isMoved == false)
        {
            _targetComponent.transform.parent = _defaultParentTransform;
        }

        _targetComponent = null;
        _isDrag = false;
        _defaultParentTransform = null;
    }
}
