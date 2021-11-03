using System;
using System.Collections;
using Logic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI
{
  public class WinWidget : MonoBehaviour
  {
    public Button RestartButton;
    public CanvasGroup Group;
    public float ShowDuration;

    private WinObserver _winObserver;
    
    [Inject]
    private void Construct(WinObserver winObserver)
    { 
      _winObserver = winObserver;

      _winObserver.Win += Show;
    }
    
    public void Awake() => 
      RestartButton.onClick.AddListener(RestartGame);

    private void Show()
    {
      _winObserver.Win -= Show;
      gameObject.SetActive(true);
      Group.alpha = 0;
      StartCoroutine(ShowAnimation());
    }

    private IEnumerator ShowAnimation()
    {
      float duration = 0;
      while (ShowDuration > duration)
      {
        duration += Time.deltaTime;
        Group.alpha = Mathf.Clamp(duration / ShowDuration, 0, 1);
        yield return null;
      }
    }

    private void RestartGame() => 
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}