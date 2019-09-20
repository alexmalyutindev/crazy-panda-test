using System;
using UnityEngine;
using UnityEngine.UI;

public class LobbyView : BaseMenuView
{
    public Action OnPlay;

    [SerializeField]
    private Button _play;

    void Start() => _play.onClick.AddListener(() => OnPlay?.Invoke());
}
