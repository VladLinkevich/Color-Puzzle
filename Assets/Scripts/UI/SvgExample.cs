using System.IO;
using Unity.VectorGraphics;
using UnityEngine;

public class SvgExample : MonoBehaviour
{
  public Color color;

  private void Start()
  {
    var file = "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 100 100\">" +
               "<path id =\"path5635\" " +
               "d =\"m 256,342.5 c -2.988,-4.353 -4.224,-16.005 -4.224,-16.005 0,0 -12.516,12.865 -22.585,26.184 " +
               "-10.07,13.318 -18.961,23.69 -32.018,32.656 -13.06,8.966 -55.413,44.449 -58.141,59.132 0,0 -2.532,8.533 " +
               "6.468,11.533 9,3 22,-3 31.5,-9.5 9.5,-6.5 31.5,-22 38.374,-33.1 5.995,-9.682 20.626,-38.9 27.126,-49.4 " +
               "5.843,-9.439 13.5,-21.5 13.5,-21.5 z\" " +
               "style=\"fill:#aa0e0e\" />" +
               "</svg>";

    var scene = SVGParser.ImportSVG(new StringReader(file));

    color = ((SolidFill)scene.NodeIDs["path5635"].Shapes[0].Fill).Color;
  }
}