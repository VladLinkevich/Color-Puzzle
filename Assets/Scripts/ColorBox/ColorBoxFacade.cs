using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.U2D;

namespace ColorBox
{
  public class ColorBoxFacade : MonoBehaviour
  {
    public List<ColorBoxFacade> Neighbors = new List<ColorBoxFacade>();
    public ColorType CurrentColor;
    public SpriteShapeRenderer Body;
    
    public bool ChangeColor(ColorType currentColor)
    {
      if (CurrentColor == currentColor)
        return false;

      CurrentColor = currentColor;
      Body.color = ColorData.Colors[CurrentColor];
      return true;
    }

    public bool IsWin()
    {
      foreach (ColorBoxFacade neighbor in Neighbors)
        if (neighbor.CurrentColor == CurrentColor)
          return false;
      
      return true;
    }

    public void AddNeighbor(ColorBoxFacade box)
    {
      if (ContainsOrThis(box))
        return;
      
      Neighbors.Add(box);
      box.SaveAddNeighbor(this);
    }

    private void SaveAddNeighbor(ColorBoxFacade box)
    {
      if (ContainsOrThis(box))
        return;
      
      Neighbors.Add(box);
    }

    private bool ContainsOrThis(ColorBoxFacade box) => 
      box == this || Neighbors.Contains(box);
  }
}