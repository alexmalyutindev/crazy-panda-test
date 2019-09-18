using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldView : MonoBehaviour
{
    public Action<Vector2Int> OnTouch;

    [SerializeField]
    private FieldCellView _cellPrefab;
    [SerializeField]
    private Sprite _diamond;
    [SerializeField]
    private Transform _fieldContainer;

    private FieldCellView[,] _field;

    public GameFieldView Init()
    {
        _field = new FieldCellView[10, 10];

        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                var cell = Instantiate(_cellPrefab, _fieldContainer)
                    .Init(new Vector2Int(x, y));
                cell.OnTouch += () => OnTouch?.Invoke(cell.Position);

                _field[x, y] = cell;
            }
        }

        return this;
    }

    public void PlaceDiamond(Vector2Int position)
    {
        _field[position.x, position.y].PlaceItem(_diamond);
    }

    public void Dig(Vector2Int position)
    {
        _field[position.x, position.y].Dig();
    }
}
