public class UpgradePanelState : IState
{
    private readonly UpgradePanel _upgradePanel;
    private readonly UiStateMachine _uiStateMachine;
    public UpgradePanelState(UpgradePanel upgradePanel,UiStateMachine uiStateMachine)
    {
        _upgradePanel = upgradePanel;
        _uiStateMachine = uiStateMachine;
    }

    public void Enter()
    {
        _upgradePanel.ClosePanelButton.Clicked += OnClosedPanel;
        _upgradePanel.SetActive();
    }

    public void Exit()
    {
       _upgradePanel.Deactivate();
       _upgradePanel.ClosePanelButton.Clicked -= OnClosedPanel;
    }

    private void OnClosedPanel() => 
        _uiStateMachine.Enter<StartLevelState>();
}