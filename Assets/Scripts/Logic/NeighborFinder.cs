using System.Collections.Generic;
using ColorBox;
using UnityEngine;

namespace Logic
{
  public class NeighborFinder : INeighborFinder
  {
    private readonly RaycastHit2D[] _result = new RaycastHit2D[1];
    private readonly int _layer = LayerMask.GetMask("Box");

    public void FindNeighbors(List<List<Vector2>> polygons, List<ColorBoxFacade> colorBoxes)
    {
      for (int i = 0, end = polygons.Count; i < end; ++i)
      {
        ColorBoxFacade box = colorBoxes[i];
        List<Vector2> points = polygons[i];

        for (int j = 0, pointsCount = points.Count - 1; j < pointsCount; ++j) 
          FindNeighbor(points, box, j + 1, j);
        FindNeighbor(points, box, 0, points.Count - 1);
      }
    }

    private void FindNeighbor(List<Vector2> points, ColorBoxFacade box, int i, int j)
    {
      Vector2 perpendicular = Vector2.Perpendicular(points[i] - points[j]).normalized * 0.05f;
      Vector2 startPoint = Vector2.Lerp(points[i], points[j], 0.5f);
      Vector2 endPoint = startPoint - perpendicular;

      if (Physics2D.LinecastNonAlloc(startPoint, endPoint, _result, _layer) == 1)
        box.AddNeighbor(_result[0].transform.GetComponentInParent<ColorBoxFacade>());
    }
  }
}