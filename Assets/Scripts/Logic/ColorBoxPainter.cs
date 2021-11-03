using System;
using System.Collections.Generic;
using ColorBox;
using Data;

namespace Logic
{
  public class ColorBoxPainter
  {
    public event Action ChangeColor;
    
    private readonly SceneRegistrar _scene;

    private ColorType _currentColor = ColorType.Green;
    private List<ColorBoxFacade> _boxes;
    private List<ChangeColorButton> _buttons;

    public ColorBoxPainter(SceneRegistrar scene)
    {
      _scene = scene;

      _scene.Complete += GetSceneData;
    }

    private void GetSceneData()
    {
      _scene.Complete -= GetSceneData;
      
      SubscribeOnBoxTouch();
      SubscribeOnChangeColor();
    }

    private void SubscribeOnBoxTouch()
    {
      _boxes = _scene.GetColorBoxes();
      foreach (ColorBoxFacade box in _boxes) 
        box.GetComponentInChildren<TouchObserver>().Touch += ChangeBoxColor;
    }

    private void SubscribeOnChangeColor()
    {
      _buttons = _scene.GetChangeColorButton();
      foreach (ChangeColorButton button in _buttons) 
        button.Click += ChangeCurrentColor;
    }

    private void ChangeBoxColor(TouchObserver trigger)
    {
      if (trigger.GetComponentInParent<ColorBoxFacade>().ChangeColor(_currentColor))
        ChangeColor?.Invoke();
    }

    private void ChangeCurrentColor(ColorType color) => 
      _currentColor = color;
  } 
}