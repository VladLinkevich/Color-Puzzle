using Data;
using UnityEngine;

namespace ColorBox
{
  public class ColorBoxFacade : MonoBehaviour
  {
    public ColorBoxFacade[] Neighbors;
    public ColorType CurrentColor;

    private void Awake()
    {
      //Body.color = ColorData.Colors[CurrentColor];
    }

    public bool ChangeColor(ColorType currentColor)
    {
      if (CurrentColor == currentColor)
        return false;

      CurrentColor = currentColor;
      //Body.color = ColorData.Colors[CurrentColor];
      return true;
    }

    public bool IsWin()
    {
      foreach (ColorBoxFacade neighbor in Neighbors)
        if (neighbor.CurrentColor == CurrentColor)
          return false;
      
      return true;
    }
  }
}