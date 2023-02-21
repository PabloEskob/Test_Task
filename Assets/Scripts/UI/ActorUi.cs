using UnityEngine;

public class ActorUi : MonoBehaviour
{
    [SerializeField] private UpgradePanel _upgradePanel;
    [SerializeField] private OilPump _oilPump;

    private void OnEnable()
    {
        _oilPump.Clicked += _upgradePanel.SetActive;
    }

    private void OnDisable()
    {
        _oilPump.Clicked -= _upgradePanel.SetActive;
    }
} 
