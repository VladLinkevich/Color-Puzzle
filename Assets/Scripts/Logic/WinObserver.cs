using System.Collections.Generic;
using ColorBox;
using UnityEngine;

namespace Logic
{
  public class WinObserver
  {
    private readonly SceneRegistrar _scene;
    private readonly ColorBoxPainter _painter;

    private List<ColorBoxFacade> _boxes;

    public WinObserver(SceneRegistrar scene, ColorBoxPainter painter)
    {
      _scene = scene;
      _painter = painter;

      _scene.Complete += GetSceneData;
      _painter.ChangeColor += CheckWin;
    }

    private void GetSceneData()
    {
      _scene.Complete -= GetSceneData;

      _boxes = _scene.GetColorBoxes();
    }

    private void CheckWin()
    {
      foreach (ColorBoxFacade box in _boxes)
        if (box.IsWin() == false)
          return;

      Debug.Log("Win");
    }
  }
}