using System;
using UnityEngine;

namespace ColorBox
{
  public class TouchObserver : MonoBehaviour
  {
    public event Action<TouchObserver> Touch;

    private void OnMouseDown()
    {
      Debug.Log("Touch");
      Touch?.Invoke(this);
    }
  }
}