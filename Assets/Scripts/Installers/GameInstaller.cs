using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField]
    private DiggableFieldView _gameField;
    [SerializeField]
    private CounterView _shovelCounter;
    [SerializeField]
    private CounterView _diamondCounter;
    [SerializeField]
    private BackpackView _backpack;

    public GameModel Game => _game;
    private GameModel _game;

    public GameInstaller Init(GameContext context)
    {
        _game = new GameModel(context.ShovelCount, context.FieldDepth, context.DiamondProbability);
        new GamePresenter(
            _game,
            _gameField.Init(),
            _shovelCounter,
            _diamondCounter,
            _backpack
        );

        return this;
    }
}
