using System;
using System.Collections.Generic;
using ColorBox;
using SVG;
using Unity.VectorGraphics.Editor;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Logic
{
  public class LevelLoader : ILevelLoader
  {
    private const string ParentName = "Map";

    private readonly IColorBoxFactory _boxFactory;
    private readonly ISVGParser _parser;
    private readonly INeighborFinder _neighborFinder;

    private List<ColorBoxFacade> _colorBoxes;
    private Transform _parent;
    private GameObject _image;

    public List<ColorBoxFacade> ColorBoxes => _colorBoxes;

    public LevelLoader(IColorBoxFactory boxFactory, ISVGParser parser, INeighborFinder neighborFinder)
    {
      _boxFactory = boxFactory;
      _parser = parser;
      _neighborFinder = neighborFinder;
      
      _parent = new GameObject(ParentName).transform;
    }

    public void LoadLevel(int level)
    {
      Cleanup();

      SpriteRenderer renderer = Resources.Load<SpriteRenderer>("Sprite/" + level);
      List<List<Vector2>> polygons = _parser.ToPolygonData(GetPath(level), renderer.sprite.pixelsPerUnit);
      _colorBoxes = new List<ColorBoxFacade>(polygons.Count);

      foreach (List<Vector2> polygon in polygons)
        _colorBoxes.Add(
          _boxFactory.CreateColorBox(polygon.ToArray(), _parent).GetComponent<ColorBoxFacade>());

      _neighborFinder.FindNeighbors(polygons, _colorBoxes);
      
      _image = CreateImage(renderer.gameObject);
      SetTransform(renderer);
    }

    private void Cleanup()
    {
      if (_colorBoxes == null)
        return;
      
      foreach (ColorBoxFacade box in _colorBoxes) 
        Object.Destroy(box.gameObject);

      Object.Destroy(_image.gameObject);
      _colorBoxes.Clear();
    }

    private GameObject CreateImage(GameObject image)
    {
      GameObject instantiate = Object.Instantiate(image);
      instantiate.transform.eulerAngles = new Vector3(0, -180, 0);

      return instantiate;
    }

    private void SetTransform(SpriteRenderer renderer)
    {
      _parent.transform.eulerAngles = new Vector3(0, 0, 180);
      _parent.position = new Vector3(renderer.size.x / 2, renderer.size.y / 2, 0);
    }

    private static string GetPath(int level) =>
      Application.dataPath + "/Resources/Sprite/" + level + ".svg";
  }
}