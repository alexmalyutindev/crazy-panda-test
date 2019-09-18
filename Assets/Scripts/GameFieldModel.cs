using UnityEngine;

public class GameFieldModel
{
    private readonly float _diamondSpawProbability;

    public GameFieldModel(float diamondSpawProbability = 0.5f)
    {
        _diamondSpawProbability = diamondSpawProbability;
    }

    public bool TryGetDiamond()
    {
        return Random.Range(0f, 1f) < _diamondSpawProbability;
    }
}
