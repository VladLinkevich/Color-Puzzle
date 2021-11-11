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
    private readonly StartButton _startButton;

    public StartGameState(
      ILevelLoader loader,
      GameStateMachine stateMachine,
      StartButton startButton)
    {
      _loader = loader;
      _stateMachine = stateMachine;
      _startButton = startButton;
    }

    public void Enter()
    {
      CreateLevel();
      InitializeButton();
    }

    public void Exit() => 
      _startButton.gameObject.SetActive(false);

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

    private void EnterGameLoop() => 
      _stateMachine.Enter<GameLoopState>();

    private void CreateLevel() => 
      _loader.LoadLevel(GetLevel());
  }
}