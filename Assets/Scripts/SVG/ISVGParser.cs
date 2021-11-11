using System.Collections.Generic;
using UnityEngine;

namespace SVG
{
  public interface ISVGParser
  {
    List<List<Vector2>> ToPolygonData(string path);
  }
}