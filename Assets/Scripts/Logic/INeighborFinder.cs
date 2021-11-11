using System.Collections.Generic;
using ColorBox;
using UnityEngine;

namespace Logic
{
  public interface INeighborFinder
  {
    void FindNeighbors(List<List<Vector2>> polygons, List<ColorBoxFacade> colorBoxes);
  }
}