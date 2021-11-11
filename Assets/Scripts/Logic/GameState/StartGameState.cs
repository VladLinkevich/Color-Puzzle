using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Logic.GameState
{
  public class StartGameState : IState
  {
    private const string LevelKey = "level";
    private readonly ILevelLoader _loader;
    private readonly GameStateMachine _stateMachine;
    private readonly WinObserver _winObserver;
    private readonly StartButton _startButton;
    private readonly Label _label;

    public StartGameState(
      ILevelLoader loader,
      GameStateMachine stateMachine,
      WinObserver winObserver,
      StartButton startButton,
      Label label)
    {
      _loader = loader;
      _stateMachine = stateMachine;
      _winObserver = winObserver;
      _startButton = startButton;
      _label = label;
    }

    public void Enter()
    {
      _winObserver.Win += ChangeState;
      
      CreateLevel();
      InitializeUI();
    }

    private void InitializeUI()
    {
      InitializeButton();
      InitializeLabel();
    }

    private void InitializeLabel()
    {
      _label.gameObject.SetActive(true);
      _label.Text.text = "Level " + (GetLevel() + 1);
    }

    public void Exit()
    {
      _label.gameObject.SetActive(false);
      _startButton.gameObject.SetActive(false);
    }

    private void InitializeButton()
    {
      _startButton.gameObject.SetActive(true);
      _startButton.Button.onClick.AddListener(EnterGameLoop);
    }

    private  int GetLevel()
    {
      int level = PlayerPrefs.HasKey(LevelKey) ? PlayerPrefs.GetInt(LevelKey) : 0;
      
      if (level == 3)
        level = 0;
      
      return level;
    }

    private void ChangeState()
    {
      _winObserver.Win -= ChangeState;
      _stateMachine.Enter<WinState>();
    }

    private void EnterGameLoop() => 
      _stateMachine.Enter<GameLoopState>();

    private void CreateLevel() => 
      _loader.LoadLevel(GetLevel());
  }
}