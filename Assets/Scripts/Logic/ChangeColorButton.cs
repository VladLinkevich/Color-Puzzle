using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
  public class ChangeColorButton : MonoBehaviour
  {
    public event Action<ColorType> Click;

    public Button Button;
    public ColorType Color;

    private void Awake() => 
      Button.onClick.AddListener(OnClick);

    private void OnClick() => 
      Click?.Invoke(Color);
  }
}