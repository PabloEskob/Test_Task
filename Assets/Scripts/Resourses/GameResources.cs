using UnityEngine;

public class GameResources : MonoBehaviour
{
    private Money _money;
    private Oil _oil;
    private int _countOil;

    public Money Money => _money;
    public Oil Oil => _oil;

    private void Awake()
    {
        _money = GetComponentInChildren<Money>();
        _oil = GetComponentInChildren<Oil>();
    }

    public void SetOil(int value)
    {
        _oil.Add(value);
    }

    public void RemoveOil()
    {
        _countOil = _oil.Count;
        _oil.Remove(_countOil);
        SetMoney(_countOil);
    }

    public void SetMoney(int value)
    {
        _money.Add(value);
    }

    public void RemoveMoney(int value)
    {
        _money.Remove(value);
    }
}