using System;

namespace Logic.GameState
{
  public class GameLoopState : IState
  {
    private readonly ILevelDataListener[] _listeners;
    private readonly ILevelLoader _loader;

    public GameLoopState(ILevelDataListener[] listeners, ILevelLoader loader)
    {
      _listeners = listeners;
      _loader = loader;
    }

    public void Enter()
    {
      foreach (ILevelDataListener listener in _listeners) 
        listener.GetLevelData(_loader.ColorBoxes);
    }

    public void Exit()
    {
      foreach (ILevelDataListener listener in _listeners) 
        listener.Cleanup();
    }
  }
}