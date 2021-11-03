using System.Collections.Generic;
using UnityEngine;

namespace Data
{
  public class ColorData
  {
    public static Dictionary<ColorType, Color> Colors = new Dictionary<ColorType, Color>
    {
      [ColorType.White] = Color.white,
      [ColorType.Blue] = Color.blue,
      [ColorType.Green] = Color.green,
      [ColorType.Yellow] = Color.yellow
    };
  }
}