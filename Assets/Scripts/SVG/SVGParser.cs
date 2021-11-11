using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//using UnityEngine;

namespace SVG
{
  public class SVGParser
  {
    public List<List<Vector2>> ToPolygonData()
    {
      List<List<Vector2>> polygons = new List<List<Vector2>>();

      string data = File.ReadAllText("C:\\Users\\mipro\\Downloads\\Dragonfly.svg");

      float scale = GetScale(data);
      
      string[] polygonsData = data.Split(new string[] {"polygon points=\""},
        StringSplitOptions.RemoveEmptyEntries);

      for (int i = 1, end = polygonsData.Length; i < end; ++i)
      {
        string polygon = polygonsData[i].Remove(polygonsData[i].IndexOf('"'));
        string[] vector2Data = polygon.Split(' ');
        List<Vector2> points = new List<Vector2>(vector2Data.Length / 2);

        for (int j = 0, endJ = vector2Data.Length; j < endJ; j += 2)
        {
          points.Add(new Vector2(
            float.Parse(vector2Data[j]) / scale,
            float.Parse(vector2Data[j + 1]) / scale));
        }

        foreach (Vector2 point in points)
        {
          Debug.Log(point);
        }
        
        polygons.Add(points);
      }

      return polygons;
    }

    private float GetScale(string data)
    {
      data = data.Substring(data.IndexOf("viewBox=\"", StringComparison.Ordinal) + 9);
      data = data.Remove(data.IndexOf('"'));
      
      string[] resolution = data.Split(' ');
      
      return (1920 * 200) / float.Parse(resolution[2]) - float.Parse(resolution[0]);
    }
  }
}