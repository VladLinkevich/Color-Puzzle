using System;
using System.Collections.Generic;
using ColorBox;
using UnityEngine;
using Zenject;

namespace Logic
{
  public class SceneRegistrar : IInitializable
  {
    private const string ColorBoxTag = "ColorBox";

    public event Action Complete;
    
    private List<ColorBoxFacade> _colorBoxes;

    public void Initialize()
    {
      RegisterColorBox();

      Complete?.Invoke();
    }

    public List<ColorBoxFacade> GetColorBoxes() => 
      _colorBoxes;

    private void RegisterColorBox()
    {
      GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(ColorBoxTag);
      _colorBoxes = new List<ColorBoxFacade>(gameObjects.Length);

      foreach (GameObject gameObject in gameObjects)
        _colorBoxes.Add(gameObject.GetComponent<ColorBoxFacade>());
    }
  }
}