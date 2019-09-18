using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInstaller : MonoBehaviour
{
    [SerializeField]
    private GameFieldView _gameField;

    void Start()
    {
        _gameField.Init();
        var model = new GameFieldModel(0.1f);

        new GameFieldPresenter(model, _gameField);
    }
}
