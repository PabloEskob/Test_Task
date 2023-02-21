using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class OilPump : MonoBehaviour, IPointerClickHandler
{
    private Coroutine _coroutine;
    private int _delay = 10;
    private int _countOil = 10;
    public event Action Clicked;
    public event Action<int> GotOil;

    private void OnDisable() =>
        StopCoroutine(_coroutine);

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke();
    }

    private void Start()
    {
        _coroutine = StartCoroutine(OilProduction());
    }

    private IEnumerator OilProduction()
    {
        var delay = new WaitForSeconds(_delay);

        while (true)
        {
            yield return delay;
            GotOil?.Invoke(_countOil);
        }
    }
}