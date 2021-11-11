using System;
using System.Collections.Generic;
using ColorBox;

namespace Logic
{
  public interface ILevelLoader
  {
    event Action Complete;
    List<ColorBoxFacade> ColorBoxes { get; }
  }
}