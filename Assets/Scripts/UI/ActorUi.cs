using UnityEngine;

public class ActorUi : MonoBehaviour
{
    [SerializeField] private UpgradePanel _upgradePanel;
    [SerializeField] private OilPump _oilPump;
    [SerializeField] private Oil _oil;
    [SerializeField] private InfographicPanel _infographicPanel;
    [SerializeField] private OpenInfographicPanelButton _openInfographicPanelButton;
    
    private UiStateMachine _uiStateMachine;

    private void OnEnable()
    {
        _oilPump.GotOil += _oil.Add;
        _openInfographicPanelButton.Clicked += EnterInfographicPanel;
    }

    private void OnDisable()
    {
        _oilPump.GotOil -= _oil.Add;
        _openInfographicPanelButton.Clicked -= EnterInfographicPanel;
    }

    private void Start()
    {
        _uiStateMachine = new UiStateMachine(_infographicPanel,_upgradePanel,_oilPump);
    }

    private void EnterInfographicPanel() => 
        _uiStateMachine.Enter<InfographicPanelState>();
}