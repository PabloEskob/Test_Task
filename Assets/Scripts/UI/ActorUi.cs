using UnityEngine;

public class ActorUi : MonoBehaviour
{
    [SerializeField] private UpgradePanel _upgradePanel;
    [SerializeField] private OilPump _oilPump;
    [SerializeField] private GameResources _gameResources;
    [SerializeField] private InfographicPanel _infographicPanel;
    [SerializeField] private OpenInfographicPanelButton _openInfographicPanelButton;

    private UiStateMachine _uiStateMachine;

    public GameResources GameResources => _gameResources;
    public OilPump OilPump => _oilPump;

    private void OnEnable()
    {
        _oilPump.GotOil += _gameResources.SetOil;
        _openInfographicPanelButton.Clicked += EnterInfographicPanel;
        _upgradePanel.Changed += _gameResources.Money.Remove;
    }

    private void OnDisable()
    {
        _oilPump.GotOil -= _gameResources.SetOil;
        _openInfographicPanelButton.Clicked -= EnterInfographicPanel;
        _upgradePanel.Changed += _gameResources.Money.Remove;
    }

    private void Start()
    {
        _uiStateMachine = new UiStateMachine(_infographicPanel,_upgradePanel,_oilPump);
    }

    private void EnterInfographicPanel() => 
        _uiStateMachine.Enter<InfographicPanelState>();
}