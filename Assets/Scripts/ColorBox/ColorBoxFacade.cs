using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;
using UnityEngine.U2D;

namespace ColorBox
{
  public class ColorBoxFacade : MonoBehaviour
  {
    public List<ColorBoxFacade> Neighbors = new List<ColorBoxFacade>();
    public SpriteShapeRenderer Body;
    public Guid ID;
    
    private ColorType _currentColor;

    public ColorType GetColor => _currentColor;

    public bool ChangeColor(ColorType currentColor)
    {
      if (_currentColor == currentColor)
        return false;

      _currentColor = currentColor;
      Body.color = ColorData.Colors[_currentColor];
      return true;
    }

    public bool IsWin()
    {
      if (_currentColor == ColorType.White) return false;
      
      foreach (ColorBoxFacade neighbor in Neighbors)
        if (neighbor._currentColor == _currentColor)
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
      box.ID == this.ID || Neighbors.FirstOrDefault((x) => x.ID == box.ID);
  }
}