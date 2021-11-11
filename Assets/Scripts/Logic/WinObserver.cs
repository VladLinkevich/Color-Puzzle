using System;
using System.Collections.Generic;
using ColorBox;
using Unity.VectorGraphics;
using Unity.VectorGraphics.Editor;
using UnityEngine;

namespace Logic
{
  public class WinObserver
  {
    public event Action Win;
    
    private readonly ILevelLoader _level;
    private readonly ColorBoxPainter _painter;
    
    private List<ColorBoxFacade> _boxes;

    public WinObserver(ILevelLoader level, ColorBoxPainter painter)
    {
      _level = level;
      _painter = painter;

      _level.Complete += GetSceneData;
      _painter.ChangeColor += CheckWin;
    }

    private void GetSceneData()
    {
      _level.Complete -= GetSceneData;
      _boxes = _level.ColorBoxes;
    }

    private void CheckWin()
    {
      foreach (ColorBoxFacade box in _boxes)
        if (box.IsWin() == false)
          return;

      Win?.Invoke();
    }
  }
}