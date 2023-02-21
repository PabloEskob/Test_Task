using UnityEngine;

public class ActorUi : MonoBehaviour
{
    [SerializeField] private UpgradePanel _upgradePanel;
    [SerializeField] private OilPump _oilPump;
    [SerializeField] private Oil _oil;

    private void OnEnable()
    {
        _oilPump.Clicked += _upgradePanel.SetActive;
        _oilPump.GotOil += _oil.Add;
    }

    private void OnDisable()
    {
        _oilPump.Clicked -= _upgradePanel.SetActive;
        _oilPump.GotOil -= _oil.Add;
    }
}