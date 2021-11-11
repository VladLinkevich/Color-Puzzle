using System;
using System.Collections.Generic;
using ColorBox;
using UI;
using UnityEngine;
using Zenject;

namespace Logic
{
  public class SceneRegistrar : IInitializable
  {
    private const string ColorBoxTag = "ColorBox";
    private const string ChangeColorButtonTag = "ColorChangeButton";

    public event Action Complete;
    
    private List<ColorBoxFacade> _colorBoxes;
    private List<ChangeColorButton> _changeColorButton;

    public void Initialize()
    {
      RegisterColorBox();
      RegisterChangeColorButton();

      Complete?.Invoke();
    }

    public List<ColorBoxFacade> GetColorBoxes() => 
      _colorBoxes;

    public List<ChangeColorButton> GetChangeColorButton() => 
      _changeColorButton;

    private void RegisterColorBox()
    {
      GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(ColorBoxTag);
      _colorBoxes = new List<ColorBoxFacade>(gameObjects.Length);

      foreach (GameObject gameObject in gameObjects)
        _colorBoxes.Add(gameObject.GetComponent<ColorBoxFacade>());
    }

    private void RegisterChangeColorButton()
    {
      GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(ChangeColorButtonTag);
      _changeColorButton = new List<ChangeColorButton>(gameObjects.Length);

      foreach (GameObject gameObject in gameObjects)
        _changeColorButton.Add(gameObject.GetComponent<ChangeColorButton>());
    }
  }
}