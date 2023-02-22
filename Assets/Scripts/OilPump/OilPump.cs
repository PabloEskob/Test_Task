using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OilPump : MonoBehaviour, IPointerClickHandler
{
    private int _level = 1;
    private int _countOil = 10;
    private int _delay = 10;
    private int _amountMoneyForSecondLevel = 1000;
    private int _amountMoneyForThirdLevel = 5000;
    private Dictionary<int, int> _amounts;
    private Coroutine _coroutine;

    public int Level => _level;
    
    public event Action Clicked;
    public event Action<int> GotOil;

    private void OnDisable() =>
        StopCoroutine(_coroutine);

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke();
    }

    private void Awake()
    {
        _amounts = new Dictionary<int, int>
        {
            { 1, _amountMoneyForSecondLevel },
            { 2, _amountMoneyForThirdLevel }
        };
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

    public int GetValueDictionary()
    {
        _amounts.TryGetValue(_level, out int value);
        return value;
    }

    public void LevelUp()
    {
        switch (_level)
        {
            case 1:
                _countOil = 100;
                _level++;
                break;
            case 2:
                _countOil = 1000;
                _level++;
                break;
        }
    }
}