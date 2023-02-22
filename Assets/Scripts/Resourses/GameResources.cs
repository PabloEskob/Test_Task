using UnityEngine;

public class GameResources : MonoBehaviour
{
    private Money _money;
    private Oil _oil;

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

    public void SetMoney(int value)
    {
        _money.Add(value);
    }
}