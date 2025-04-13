using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSpawner : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Settings")]
    public GameObject draggablePrefab;
    public Transform parentContainer;

    private GameObject _currentDraggedObject;
    private RectTransform _rectTransform;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Create new instance
        _currentDraggedObject = Instantiate(draggablePrefab, parentContainer);

        // Match original size and position
        RectTransform newRT = _currentDraggedObject.GetComponent<RectTransform>();
        newRT.sizeDelta = _rectTransform.sizeDelta;
        newRT.anchoredPosition = _rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_currentDraggedObject == null) return;

        // Update position to follow cursor
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            parentContainer as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector3 worldPosition
        );

        _currentDraggedObject.transform.position = worldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Release reference
        _currentDraggedObject = null;
    }
}