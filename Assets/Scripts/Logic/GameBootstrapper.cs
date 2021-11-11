using Logic.GameState;
using Zenject;

namespace Logic
{
  public class GameBootstrapper : IInitializable
  {
    private readonly GameStateMachine _stateMachine;

    public GameBootstrapper(GameStateMachine stateMachine) => 
      _stateMachine = stateMachine;

    public void Initialize() => 
      _stateMachine.Enter<StartGameState>();
  }
}