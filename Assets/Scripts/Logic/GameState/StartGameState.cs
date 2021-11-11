using UnityEngine;

namespace Logic.GameState
{
  public class StartGameState : IState
  {
    private const string LevelKey = "level";
    private readonly ILevelLoader _loader;

    public StartGameState(ILevelLoader loader)
    {
      _loader = loader;
    }

    public void Enter()
    {
      CreateLevel();
    }

    public void Exit()
    {
      
    }

    private  int GetLevel()
    {
      int level = PlayerPrefs.HasKey(LevelKey) ? PlayerPrefs.GetInt(LevelKey) : 0;
      
      if (level == 3)
        level = 0;
      
      return level;
    }

    private void CreateLevel() => 
      _loader.LoadLevel(GetLevel());
  }
}