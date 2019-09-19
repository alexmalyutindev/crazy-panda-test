using System;
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
    private int _nonCollectedDiamondCount;

    public GameModel(int initialShovelCount, float diamondSpawProbability = 0.5f)
    {
        _shovelCount = initialShovelCount;
        _diamondSpawProbability = diamondSpawProbability;
        _collectedDiamondCount = 0;
    }

    public bool CanDig()
    {
        if (IsGameOver())
            OnGameOver?.Invoke();

        return _shovelCount > 0;
    }
    public bool TryDigDiamond()
    {
        if (_shovelCount <= 0)
            return false;

        _shovelCount--;
        OnShavelCountChanged?.Invoke(_shovelCount);

        var isFound = Random.Range(0f, 1f) < _diamondSpawProbability;
        if (isFound)
            _nonCollectedDiamondCount++;
        return isFound;
    }

    public void CollectDiamond()
    {
        _nonCollectedDiamondCount--;
        _collectedDiamondCount++;
        OnDiamondCountChanged?.Invoke(_collectedDiamondCount);
        _shovelCount += 3;
        OnShavelCountChanged?.Invoke(_shovelCount);
    }

    private bool IsGameOver() => _shovelCount <= 0 && _nonCollectedDiamondCount == 0;
}
