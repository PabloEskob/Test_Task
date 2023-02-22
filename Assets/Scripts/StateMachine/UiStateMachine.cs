using System;
using System.Collections.Generic;

public class UiStateMachine
{
    private Dictionary<Type, IState> _states;
    private IState _currentLevelState;

    public UiStateMachine(InfographicPanel infographicPanel, UpgradePanel upgradePanel, OilPump oilPump)
    {
        InitStates(infographicPanel,upgradePanel,oilPump);
        Enter<StartLevelState>();
    }

    public void Enter<TState>() where TState : class, IState
    {
        var state = SetState<TState>();
        state.Enter();
    }

    private void InitStates(InfographicPanel infographicPanel, UpgradePanel upgradePanel, OilPump oilPump)
    {
        _states = new Dictionary<Type, IState>
        {
            [typeof(StartLevelState)] = new StartLevelState(oilPump,this),
            [typeof(UpgradePanelState)] = new UpgradePanelState(upgradePanel,this),
            [typeof(InfographicPanelState)] = new InfographicPanelState(infographicPanel,this)
        };
    }

    private TState SetState<TState>() where TState : class, IState
    {
        _currentLevelState?.Exit();
        IState state = GetState<TState>();
        _currentLevelState = state;
        return (TState)state;
    }

    private IState GetState<T>() where T : IState
    {
        var type = typeof(T);
        return _states[type];
    }
}