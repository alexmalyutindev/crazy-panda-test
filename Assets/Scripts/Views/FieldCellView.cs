using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FieldCellView : MonoBehaviour, IPointerClickHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Action<FieldCellView> OnTouch;
    public Action<BaseEventData> OnItemGrabed;

    public Vector2Int Position => _position;

    public GameObject Item => _item;

    [SerializeField]
    private Image _ground;
    [SerializeField]
    private GameObject _item;

    private Vector2Int _position;

    public FieldCellView Init(Vector2Int position)
    {
        _position = position;
        return this;
    }

    public void PlaceItem(GameObject item)
    {
        _item = item;
        _item.transform.SetParent(transform);
    }

    public void Dig()
    {
        _ground.color = Color.Lerp(_ground.color, Color.black, 0.1f);
    }
    public GameObject ReleaseItem()
    {
        var item = _item;
        _item = null;
        return item;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (_item == null)
            OnTouch?.Invoke(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_item != null)
            _item.transform.SetParent(base.transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_item != null)
            _item.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_item != null)
            _item.transform.SetParent(transform);
    }
}