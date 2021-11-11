using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



namespace SVG
{
  public class SVGParser : ISVGParser
  {
    public List<List<Vector2>> ToPolygonData(string path, float ppu)
    {
      List<List<Vector2>> polygons = new List<List<Vector2>>();

      string data = File.ReadAllText(path);

      string[] polygonsData = data.Split(new string[] {"polygon points=\""},
        StringSplitOptions.RemoveEmptyEntries);

      for (int i = 1, end = polygonsData.Length; i < end; ++i)
      {
        string polygon = polygonsData[i].Remove(polygonsData[i].IndexOf('"'));
        string[] vector2Data = polygon.Split(' ');
        List<Vector2> points = new List<Vector2>(vector2Data.Length / 2);

        for (int j = 0, endJ = vector2Data.Length - 2; j < endJ; j += 2)
        {
          points.Add(new Vector2(
            float.Parse(vector2Data[j]) / ppu,
            float.Parse(vector2Data[j + 1]) / ppu));
        }

        polygons.Add(points);
      }

      return polygons;
    }
  }
}