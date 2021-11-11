using System;
using System.Collections.Generic;
using ColorBox;
using SVG;
using UnityEngine;
using Zenject;

namespace Logic
{
  public class LevelLoader : IInitializable, ILevelLoader
  {
    public event Action Complete;
    
    private readonly IColorBoxFactory _boxFactory;
    private readonly ISVGParser _parser;

    private List<ColorBoxFacade> _colorBoxes;
    private Transform _parent;

    public List<ColorBoxFacade> ColorBoxes => _colorBoxes;

    public LevelLoader(IColorBoxFactory boxFactory, ISVGParser parser)
    {
      _boxFactory = boxFactory;
      _parser = parser;
    }

    public void Initialize()
    {
      _parent = new GameObject("Map").transform;
      List<List<Vector2>> polygons = _parser.ToPolygonData(GetPath());

      _colorBoxes = new List<ColorBoxFacade>(polygons.Count);
      
      foreach (List<Vector2> polygon in polygons) 
        _colorBoxes.Add(
          _boxFactory.CreateColorBox(polygon.ToArray(), _parent).GetComponent<ColorBoxFacade>());
      
      Complete?.Invoke();
    }

    private static string GetPath() => 
      Application.dataPath + "/Sprites/Levels/Dragonfly.svg";
  }
}