public class StartLevelState : IState
{
    private readonly OilPump _oilPump;
    private readonly UiStateMachine _uiStateMachine;

    public StartLevelState(OilPump oilPump,UiStateMachine uiStateMachine)
    {
        _oilPump = oilPump;
        _uiStateMachine = uiStateMachine;
    }

    public void Enter() => 
        _oilPump.Clicked += EnterStateUpgradePanel;

    public void Exit() => 
        _oilPump.Clicked -= EnterStateUpgradePanel;

    private void EnterStateUpgradePanel() => 
        _uiStateMachine.Enter<UpgradePanelState>();
}