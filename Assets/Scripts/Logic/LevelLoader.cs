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

      SpriteRenderer renderer = Resources.Load<SpriteRenderer>("Sprite/Dragonfly");
      List<List<Vector2>> polygons = _parser.ToPolygonData(GetPath(), renderer.sprite.pixelsPerUnit);
      _colorBoxes = new List<ColorBoxFacade>(polygons.Count);

      foreach (List<Vector2> polygon in polygons)
        _colorBoxes.Add(
          _boxFactory.CreateColorBox(polygon.ToArray(), _parent).GetComponent<ColorBoxFacade>());

      CreateImage(renderer.gameObject);
      SetTransform(renderer);
      
      Complete?.Invoke();
    }

    private void CreateImage(GameObject image)
    {
      GameObject instantiate = Object.Instantiate(image);
      instantiate.transform.eulerAngles = new Vector3(0, -180, 0);
    }

    private void SetTransform(SpriteRenderer renderer)
    {
      _parent.transform.eulerAngles = new Vector3(0, 0, 180);
      _parent.position = new Vector3(renderer.size.x / 2, renderer.size.y / 2, 0);
    }

    private static string GetPath() =>
      Application.dataPath + "/Resources/Sprite/Dragonfly.svg";
  }
}