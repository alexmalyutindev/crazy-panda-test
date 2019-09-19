using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInstaller : MonoBehaviour
{
    [SerializeField]
    private DiggableFieldView _gameField;
    [SerializeField]
    private CounterView _shovelCounter;
    [SerializeField]
    private CounterView _diamondCounter;
    [SerializeField]
    public BackpackView _backpack;

    void Start()
    {
        new GamePresenter(
            new GameModel(99, 6, 0.1f),
            _gameField.Init(),
            _shovelCounter,
            _diamondCounter,
            _backpack
        );
    }
}
