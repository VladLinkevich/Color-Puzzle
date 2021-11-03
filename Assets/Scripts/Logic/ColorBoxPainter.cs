using System.Collections.Generic;
using ColorBox;
using Data;
using UnityEngine;

namespace Logic
{
  public class ColorBoxPainter
  {
    private readonly SceneRegistrar _scene;

    private ColorType _currentColor = ColorType.Green;
    private List<ColorBoxFacade> _boxes;

    public ColorBoxPainter(SceneRegistrar scene)
    {
      _scene = scene;

      _scene.Complete += GetColorBox;
    }

    private void GetColorBox()
    {
      _scene.Complete -= GetColorBox;

      _boxes = _scene.GetColorBoxes();
      Debug.Log($"{_boxes.Count}");
      SubscribeOnBoxTouch();
    }

    private void SubscribeOnBoxTouch()
    {
      foreach (ColorBoxFacade box in _boxes) 
        box.GetComponentInChildren<TouchObserver>().Touch += ChangeColor;
    }

    private void ChangeColor(TouchObserver trigger) => 
      trigger.GetComponentInParent<ColorBoxFacade>().ChangeColor(_currentColor);
  } 
}