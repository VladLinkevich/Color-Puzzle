using System;
using Data;
using Logic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
  public class ChangeColorButton : MonoBehaviour
  {
    public Button Button;
    public ColorType Color;
    
    private ColorBoxPainter _painter;

    [Inject]
    private void Construct(ColorBoxPainter painter)
    {
      _painter = painter;
    }
    
    private void Awake() => 
      Button.onClick.AddListener(OnClick);

    private void OnClick() => 
      _painter.SetPaintColor(Color);
  }
}