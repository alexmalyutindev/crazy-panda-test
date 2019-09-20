using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : BaseMenuView
{
    public Action OnLobby;
    public Action OnRestart;

    [SerializeField]
    private Button _lobby;
    [SerializeField]
    private Button _restart;

    public void Start()
    {
        _lobby.onClick.AddListener(() => OnLobby?.Invoke());
        _restart.onClick.AddListener(() => OnRestart?.Invoke());
    }
}