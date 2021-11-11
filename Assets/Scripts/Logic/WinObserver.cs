using System;
using System.Collections.Generic;
using ColorBox;

namespace Logic
{
  public class WinObserver : ILevelDataListener
  {
    public event Action Win;
    
    private readonly ColorBoxPainter _painter;
    
    private List<ColorBoxFacade> _boxes;

    public WinObserver(ColorBoxPainter painter)
    {
      _painter = painter;
      
      _painter.ChangeColor += CheckWin;
    }

    public void GetLevelData(List<ColorBoxFacade> boxes) => 
      _boxes = boxes;

    public void Cleanup() => 
      _boxes = null;

    private void CheckWin()
    {
      foreach (ColorBoxFacade box in _boxes)
        if (box.IsWin() == false)
          return;

      Win?.Invoke();
    }
  }
}