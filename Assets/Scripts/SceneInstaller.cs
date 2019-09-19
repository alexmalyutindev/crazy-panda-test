using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInstaller : MonoBehaviour
{
    [SerializeField]
    private DiggableFieldView _gameField;
    [SerializeField]
    private CounterView _shovelConter;
    [SerializeField]
    private CounterView _diamondCounter;

    void Start()
    {
        _gameField.Init();
        var model = new GameModel(99, 0.1f);

        new GamePresenter(model, _gameField, _shovelConter, _diamondCounter);
    }
}
