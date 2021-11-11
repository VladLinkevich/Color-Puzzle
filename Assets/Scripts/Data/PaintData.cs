using System;

namespace Data
{
  public class PaintData
  {
    public Guid ID;
    public ColorType Color;

    public PaintData(Guid id, ColorType color)
    {
      ID = id;
      Color = color;
    }
  }
}