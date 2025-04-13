using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();

        // Auto-add CanvasGroup if missing
        if (_canvasGroup == null)
            _canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Allow dragging
        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false; // Disable raycast blocking
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Update position to follow cursor
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
        // Restore defaults
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }
}