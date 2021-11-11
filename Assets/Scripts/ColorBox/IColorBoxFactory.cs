using UnityEngine;

namespace ColorBox
{
  public interface IColorBoxFactory
  {
    GameObject CreateColorBox(Vector2[] polygon, Transform parent);
  }
}