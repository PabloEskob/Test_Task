public class InfographicPanelState : IState
{
    private readonly InfographicPanel _infographicPanel;
    private readonly UiStateMachine _uiStateMachine;

    public InfographicPanelState(InfographicPanel infographicPanel, UiStateMachine uiStateMachine)
    {
        _infographicPanel = infographicPanel;
        _uiStateMachine = uiStateMachine;
    }

    public void Enter()
    {
        _infographicPanel.Activate();
        _infographicPanel.ClosePanelButton.Clicked += OnClosedPanel;
    }

    public void Exit()
    {
        _infographicPanel.Deactivate();
        _infographicPanel.ClosePanelButton.Clicked -= OnClosedPanel;
    }

    private void OnClosedPanel() => 
        _uiStateMachine.Enter<StartLevelState>();
}