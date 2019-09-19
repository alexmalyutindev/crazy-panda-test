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
    private Coroutine _showDeltaCoroutine;
    private int _count;

    void Start()
    {
        _counterText.text = _count.ToString();
        _deltaText.gameObject.SetActive(false);
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
        if (_showDeltaCoroutine != null)
            StopCoroutine(_showDeltaCoroutine);
        _showDeltaCoroutine = StartCoroutine(ShowDeltaCoroutine(delta));
    }

    private IEnumerator ShowDeltaCoroutine(int delta)
    {
        var sign = delta > 0 ? "+" : "-";
        _deltaText.text = $"{sign}{Mathf.Abs(delta)}";

        _deltaText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        _deltaText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        _deltaText.gameObject.SetActive(false);
    }
}
