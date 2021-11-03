using Data;
using UnityEngine;

namespace ColorBox
{
  public class ColorBoxFacade : MonoBehaviour
  {
    public ColorBoxFacade[] Neighbor;
    public SpriteRenderer Body;
    public ColorType CurrentColor;

    private void Awake()
    {
      Body.color = ColorData.Colors[CurrentColor];
    }

    public void ChangeColor(ColorType currentColor)
    {
      if (CurrentColor == currentColor)
        return;

      CurrentColor = currentColor;
      Body.color = ColorData.Colors[CurrentColor];
    }
  }
}