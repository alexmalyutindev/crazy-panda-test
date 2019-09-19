using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [SerializeField]
    private Text _counterText;
    [SerializeField]
    private Text _deltaText;

    private int _count;

    void Start()
    {
        _counterText.text = _count.ToString();
        _deltaText.CrossFadeAlpha(0, 0, true);
    }

    public void SetCount(int count)
    {
        if (_count != count)
        {
            ShowDelta(count - _count);
            _count = count;
            _counterText.text = count.ToString();
        }
    }

    private void ShowDelta(int delta)
    {
        var sign = delta > 0 ? "+" : "-";
        _deltaText.text = $"{sign}{Mathf.Abs(delta)}";
        // var currentColor = _deltaText.color;
        // currentColor.a = 1;
        // _deltaText.color = currentColor;
        _deltaText.CrossFadeAlpha(1, 0, true);
        _deltaText.CrossFadeAlpha(0, 0.5f, true);
    }
}
