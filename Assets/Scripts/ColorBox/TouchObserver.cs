using System;
using UnityEngine;

namespace ColorBox
{
  public class TouchObserver : MonoBehaviour
  {
    public event Action<TouchObserver> Touch;

    private void OnMouseDown() => 
      Touch?.Invoke(this);
  }
}