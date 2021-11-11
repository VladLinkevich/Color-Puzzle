using System;
using System.Collections.Generic;
using ColorBox;
using Data;
using UI;

namespace Logic
{
  public class ColorBoxPainter : ILevelDataListener
  {
    public event Action ChangeColor;

    private ColorType _currentColor = ColorType.Green;
    private List<ColorBoxFacade> _boxes;
    private List<ChangeColorButton> _buttons;
    

    public void SetPaintColor(ColorType color) => 
      _currentColor = color;

    public void GetLevelData(List<ColorBoxFacade> boxes) => 
      SubscribeOnBoxTouch(boxes);

    public void Cleanup()
    {
      foreach (ColorBoxFacade box in _boxes) 
        box.GetComponentInChildren<TouchObserver>().Touch -= ChangeBoxColor;
      _boxes = null;
    }

    private void SubscribeOnBoxTouch(List<ColorBoxFacade> boxes)
    {
      _boxes = boxes;
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