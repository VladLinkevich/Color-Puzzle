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
    private List<ChangeColorButton> _buttons;

    public ColorBoxPainter(SceneRegistrar scene)
    {
      _scene = scene;

      _scene.Complete += GetColorBox;
    }

    private void GetColorBox()
    {
      _scene.Complete -= GetColorBox;
      
      SubscribeOnBoxTouch();
      SubscribeOnChangeColor();
    }

    private void SubscribeOnBoxTouch()
    {
      _boxes = _scene.GetColorBoxes();
      foreach (ColorBoxFacade box in _boxes) 
        box.GetComponentInChildren<TouchObserver>().Touch += ChangeColor;
    }

    private void SubscribeOnChangeColor()
    {
      _buttons = _scene.GetChangeColorButton();
      foreach (ChangeColorButton button in _buttons) 
        button.Click += ChangeCurrentColor;
    }

    private void ChangeColor(TouchObserver trigger) => 
      trigger.GetComponentInParent<ColorBoxFacade>().ChangeColor(_currentColor);

    private void ChangeCurrentColor(ColorType color) => 
      _currentColor = color;
  } 
}