using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameModel
{
    public Action OnGameOver;
    public Action<int> OnShavelCountChanged;
    public Action<int> OnDiamondCountChanged;
    public int ShovelCount => _shovelCount;

    private readonly float _diamondSpawProbability;
    private int _shovelCount;
    private int _collectedDiamondCount;
    private List<Vector2Int> _nonCollectedDiamonds;

    private int _maxDiggingLevel = 6;
    private int[,] _fieldLevel;

    public GameModel(int initialShovelCount, int maxDiggingLevel, float diamondSpawProbability = 0.5f)
    {
        _shovelCount = initialShovelCount;
        _maxDiggingLevel = maxDiggingLevel;
        _diamondSpawProbability = diamondSpawProbability;
        _collectedDiamondCount = 0;

        _fieldLevel = new int[10, 10];
        _nonCollectedDiamonds = new List<Vector2Int>();
    }

    public bool CanDig(Vector2Int position)
    {
        if (IsGameOver())
        {
            OnGameOver?.Invoke();
            return false;
        }

        return _shovelCount > 0 && _fieldLevel[position.x, position.y] < _maxDiggingLevel;
    }
    public bool TryDigDiamond(Vector2Int position)
    {
        if (_shovelCount <= 0 || _fieldLevel[position.x, position.y] >= _maxDiggingLevel)
            return false;

        _shovelCount--;
        _fieldLevel[position.x, position.y]++;
        OnShavelCountChanged?.Invoke(_shovelCount);

        var isFound = Random.Range(0f, 1f) < _diamondSpawProbability;
        if (isFound)
            _nonCollectedDiamonds.Add(position);
        return isFound;
    }

    public void CollectDiamond(Vector2Int position)
    {
        _nonCollectedDiamonds.Remove(position);
        _collectedDiamondCount++;
        OnDiamondCountChanged?.Invoke(_collectedDiamondCount);
        _shovelCount += 3;
        OnShavelCountChanged?.Invoke(_shovelCount);
    }

    private bool IsGameOver() => _shovelCount <= 0 && _nonCollectedDiamonds.Count <= 0;
}
