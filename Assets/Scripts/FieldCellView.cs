using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FieldCellView : MonoBehaviour, IPointerClickHandler
{
    public Action OnTouch;

    public Vector2Int Position => _position;

    [SerializeField]
    private Image _ground;
    [SerializeField]
    private Image _item;

    private Vector2Int _position;

    public FieldCellView Init(Vector2Int position)
    {
        _position = position;
        RemoveItem();
        return this;
    }

    public void PlaceItem(Sprite itemSprite)
    {
        _item.gameObject.SetActive(true);
        _item.sprite = itemSprite;
    }

    public void RemoveItem()
    {
        _item.gameObject.SetActive(false);
        _item.sprite = null;
    }

    public void Dig()
    {
        _ground.color = Color.Lerp(_ground.color, Color.black, 0.2f);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (_item.sprite == null)
            OnTouch?.Invoke();
    }
}