using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



namespace SVG
{
  public class IsvgParser : ISVGParser
  {
    private const int PPU = 256;

    public List<List<Vector2>> ToPolygonData(string path)
    {
      List<List<Vector2>> polygons = new List<List<Vector2>>();

      string data = File.ReadAllText(path);

      float scale = GetScale(data);
      
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
            float.Parse(vector2Data[j]) / PPU,
            float.Parse(vector2Data[j + 1]) / PPU));
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

      return PPU / (float.Parse(resolution[2]) - float.Parse(resolution[0]));
    }
  }
}