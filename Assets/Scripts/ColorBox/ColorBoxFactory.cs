using System;
using UnityEngine;
using UnityEngine.U2D;

namespace ColorBox
{
  public class ColorBoxFactory : IColorBoxFactory
  {
    public GameObject CreateColorBox(Vector2[] polygon, Transform parent)
    {
      GameObject box = (GameObject) UnityEngine.Object.Instantiate(Resources.Load("Prefabs/ColorBox"), parent);

      Spline spline = box.GetComponentInChildren<SpriteShapeController>().spline;
      for (int i = 0, end = polygon.Length; i < end; ++i) 
        spline.InsertPointAt(i, polygon[i]);

      box.GetComponentInChildren<PolygonCollider2D>().points = polygon;

      box.GetComponent<ColorBoxFacade>().ID = Guid.NewGuid();
      
      
      return box;
    }
  }
}