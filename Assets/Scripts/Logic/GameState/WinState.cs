using System;
using UI;
using UnityEngine;

namespace Logic.GameState
{
  public class WinState : IState
  {
    private const string LevelKey = "level";

    private readonly GameStateMachine _stateMachine;
    private readonly WinButton _button;
    private readonly Label _label;

    public WinState(
      GameStateMachine stateMachine,
      WinButton button, 
      Label label)
    {
      _stateMachine = stateMachine;
      _button = button;
      _label = label;
    }

    public void Enter()
    {
      SetNewLevel();
      InitialUI();
    }

    public void Exit()
    {
      _button.Button.onClick.RemoveAllListeners();
      _label.gameObject.SetActive(false);
    }

    private void InitialUI()
    {
      InitialButton();
      InitialLabel();
    }

    private void InitialLabel()
    {
      _label.Text.text = "Level Complete!";
      _label.gameObject.SetActive(true);
    }

    private void InitialButton()
    {
      _button.Button.onClick.AddListener(ChangeState);
      _button.gameObject.SetActive(true);
    }

    private void ChangeState() => 
      _stateMachine.Enter<StartGameState>();

    private void SetNewLevel() => 
      PlayerPrefs.SetInt(LevelKey, PlayerPrefs.GetInt(LevelKey) + 1);
  }
}