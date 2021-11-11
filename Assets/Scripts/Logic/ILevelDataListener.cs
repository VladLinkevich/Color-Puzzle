using System.Collections.Generic;
using ColorBox;

namespace Logic
{
  public interface ILevelDataListener
  {
    void GetLevelData(List<ColorBoxFacade> boxes);
    void Cleanup();
  }
}