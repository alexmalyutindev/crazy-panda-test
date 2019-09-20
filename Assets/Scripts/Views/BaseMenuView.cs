using UnityEngine;

public class BaseMenuView : MonoBehaviour
{
    public void Hide() => gameObject.SetActive(false);

    public void Show() => gameObject.SetActive(true);
}