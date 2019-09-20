using UnityEngine;

[CreateAssetMenu(fileName = "GameContext", menuName = "Contexts/GameContext")]
public class GameContext : ScriptableObject
{
    public int ShovelCount;
    public int FieldDepth;

    [Range(0, 1)]
    public float DiamondProbability;
}