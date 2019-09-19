using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform _parent;

    private void Start()
    {
        _parent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(base.transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(_parent);
    }
}
