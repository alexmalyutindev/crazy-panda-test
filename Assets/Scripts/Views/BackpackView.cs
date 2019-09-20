using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackpackView : MonoBehaviour, IDropHandler
{
    public Action<Vector2Int> OnItemGrabed;

    public void OnDrop(PointerEventData eventData)
    {
        var cell = eventData.pointerDrag.GetComponent<FieldCellView>();
        if (cell != null && cell.Item != null)
        {
            var item = cell.ReleaseItem();
            Destroy(item);
            OnItemGrabed?.Invoke(cell.Position);
        }
    }
}
