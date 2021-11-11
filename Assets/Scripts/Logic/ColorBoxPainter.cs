using System;
using System.Collections.Generic;
using ColorBox;
using Data;
using UI;

namespace Logic
{
  public class ColorBoxPainter : ILevelDataListener
  {
    private readonly UndoButton _undoButton;
    public event Action ChangeColor;

    private ColorType _currentColor = ColorType.Green;
    private List<ColorBoxFacade> _boxes;
    private List<ChangeColorButton> _buttons;

    private Stack<PaintData> history = new Stack<PaintData>();

    public ColorBoxPainter(UndoButton undoButton) => 
      _undoButton = undoButton;

    public void SetPaintColor(ColorType color) => 
      _currentColor = color;

    public void GetLevelData(List<ColorBoxFacade> boxes)
    {
      _undoButton.Button.onClick.AddListener(UndoColor);
      SubscribeOnBoxTouch(boxes);
    }

    public void Cleanup()
    {
      history.Clear();
      _undoButton.Button.onClick.RemoveAllListeners();
      foreach (ColorBoxFacade box in _boxes) 
        box.GetComponentInChildren<TouchObserver>().Touch -= ChangeBoxColor;
      _boxes = null;
    }

    private void UndoColor()
    {
      if (history.Count == 0)
        return;
      
      PaintData paintData = history.Pop();
      
      ColorBoxFacade box = _boxes.Find(x => x.ID == paintData.ID);
      box.ChangeColor(paintData.Color);
    }

    private void SubscribeOnBoxTouch(List<ColorBoxFacade> boxes)
    {
      _boxes = boxes;
      foreach (ColorBoxFacade box in _boxes) 
        box.GetComponentInChildren<TouchObserver>().Touch += ChangeBoxColor;
    }

    private void ChangeBoxColor(TouchObserver trigger)
    {
      ColorBoxFacade box = trigger.GetComponentInParent<ColorBoxFacade>();
      ColorType color = box.GetColor;
      
      if (box.ChangeColor(_currentColor))
      {
        history.Push(new PaintData(box.ID, color));
        ChangeColor?.Invoke();
      }
    }
  }
}