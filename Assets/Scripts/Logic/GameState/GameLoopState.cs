using System;
using UI;

namespace Logic.GameState
{
  public class GameLoopState : IState
  {
    private readonly ILevelDataListener[] _listeners;
    private readonly ILevelLoader _loader;
    private readonly ChangeColorPanel _panel;
    private readonly UndoButton _undoButton;

    public GameLoopState(
      ILevelDataListener[] listeners,
      ILevelLoader loader,
      ChangeColorPanel panel,
      UndoButton undoButton)
    {
      _listeners = listeners;
      _loader = loader;
      _panel = panel;
      _undoButton = undoButton;
    }

    public void Enter()
    {
      _undoButton.gameObject.SetActive(true);
      _panel.gameObject.SetActive(true);
      foreach (ILevelDataListener listener in _listeners) 
        listener.GetLevelData(_loader.ColorBoxes);
    }

    public void Exit()
    {
      _undoButton.gameObject.SetActive(false);
      _panel.gameObject.SetActive(false);
      foreach (ILevelDataListener listener in _listeners) 
        listener.Cleanup();
    }
  }
}