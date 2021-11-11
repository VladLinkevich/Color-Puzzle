using System;
using System.Collections.Generic;
using ColorBox;

namespace Logic
{
  public interface ILevelLoader
  {
    List<ColorBoxFacade> ColorBoxes { get; }
    void LoadLevel(int level);
  }
}