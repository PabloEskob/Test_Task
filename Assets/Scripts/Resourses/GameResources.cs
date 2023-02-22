using UnityEngine;

public class GameResources : MonoBehaviour
{
    [SerializeField] private OilPrice _oilPrice;

    private Money _money;
    private Oil _oil;
    private float _countOil;

    public Money Money => _money;
    public Oil Oil => _oil;

    private void OnEnable()
    {
        _oil.Changed += _oilPrice.SetText;
    }

    private void OnDisable()
    {
        _oil.Changed-=_oilPrice.SetText;
    }

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
        SetMoney(_countOil * _oilPrice.Well);
    }

    public void SetMoney(float value)
    {
        _money.Add(value);
    }

    public void RemoveMoney(int value)
    {
        _money.Remove(value);
    }
}