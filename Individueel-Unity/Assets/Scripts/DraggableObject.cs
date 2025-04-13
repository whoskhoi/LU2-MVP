using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Settings")]
    public bool isDraggable = true; // Toggle via Inspector if needed

    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        if (_canvasGroup == null)
            _canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;

        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;

        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            _rectTransform.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector3 worldPosition
        );
        _rectTransform.position = worldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;

        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }
}