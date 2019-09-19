using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FieldCellView : MonoBehaviour,
    IPointerClickHandler, IBeginDragHandler
{
    public Action<FieldCellView> OnTouch;
    public Action<FieldCellView> OnItemGrabed;

    public Vector2Int Position => _position;
    public Sprite Item => _item.sprite;

    [SerializeField]
    private Image _ground;
    [SerializeField]
    private Image _item;

    private Vector2Int _position;

    public FieldCellView Init(Vector2Int position)
    {
        _position = position;
        GrabItem();
        return this;
    }

    public void PlaceItem(Sprite itemSprite)
    {
        _item.gameObject.SetActive(true);
        _item.sprite = itemSprite;
    }

    public Sprite GrabItem()
    {
        _item.gameObject.SetActive(false);
        var item = _item.sprite;
        _item.sprite = null;
        return item;
    }

    public void Dig()
    {
        _ground.color = Color.Lerp(_ground.color, Color.black, 0.1f);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (_item.sprite == null)
            OnTouch?.Invoke(this);
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (_item.sprite != null)
            OnItemGrabed?.Invoke(this);
    }
}