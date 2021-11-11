using System;
using UI;

namespace Logic.GameState
{
  public class GameLoopState : IState
  {
    private readonly ILevelDataListener[] _listeners;
    private readonly ILevelLoader _loader;
    private readonly ChangeColorPanel _panel;

    public GameLoopState(
      ILevelDataListener[] listeners,
      ILevelLoader loader,
      ChangeColorPanel panel)
    {
      _listeners = listeners;
      _loader = loader;
      _panel = panel;
    }

    public void Enter()
    {
      _panel.gameObject.SetActive(true);
      foreach (ILevelDataListener listener in _listeners) 
        listener.GetLevelData(_loader.ColorBoxes);
    }

    public void Exit()
    {
      _panel.gameObject.SetActive(false);
      foreach (ILevelDataListener listener in _listeners) 
        listener.Cleanup();
    }
  }
}