using System;
using System.Collections.Generic;
using ColorBox;
using Data;

namespace Logic
{
  public class ColorBoxPainter
  {
    public event Action ChangeColor;
    
    private readonly ILevelLoader _level;

    private ColorType _currentColor = ColorType.Green;
    private List<ColorBoxFacade> _boxes;
    private List<ChangeColorButton> _buttons;

    public ColorBoxPainter(ILevelLoader level)
    {
      _level = level;
      _level.Complete += GetLevelData;
    }

    private void GetLevelData()
    {
      _level.Complete -= GetLevelData;
      
      SubscribeOnBoxTouch();
    }

    private void SubscribeOnBoxTouch()
    {
      _boxes = _level.ColorBoxes;
      foreach (ColorBoxFacade box in _boxes) 
        box.GetComponentInChildren<TouchObserver>().Touch += ChangeBoxColor;
    }

    private void ChangeBoxColor(TouchObserver trigger)
    {
      if (trigger.GetComponentInParent<ColorBoxFacade>().ChangeColor(_currentColor))
        ChangeColor?.Invoke();
    }
  } 
}