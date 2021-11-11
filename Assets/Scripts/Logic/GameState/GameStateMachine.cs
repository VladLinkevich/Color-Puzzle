﻿using System;
using System.Collections.Generic;
using Zenject;

namespace Logic.GameState
{
  public class GameStateMachine
  {
    private Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    [Inject]
    public void  Construct(
      StartGameState startState,
      GameLoopState gameLoopState,
      WinState winState)
    {
      _states = new Dictionary<Type, IExitableState>
      {
        [typeof(StartGameState)] = startState,
        [typeof(GameLoopState)] = gameLoopState,
        [typeof(WinState)] = winState
      };
    }

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
      TState state = ChangeState<TState>();
      state.Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      _activeState?.Exit();

      TState state = GetState<TState>();
      _activeState = state;

      return state;
    }

    private void FillState()
    {

    }

    private TState GetState<TState>() where TState : class, IExitableState =>
      _states[typeof(TState)] as TState;
  }

  public interface IUpdatable
  {
    void Update();
  }
}