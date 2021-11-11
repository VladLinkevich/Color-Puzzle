using Logic;
using UnityEngine;
using Zenject;

namespace Installer
{
  public class SceneInstaller : MonoInstaller
  {
    public GameObject ColorBox;
    
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<SceneRegistrar>().AsSingle().NonLazy();
      Container.Bind<ColorBoxPainter>().AsSingle().NonLazy();
      Container.Bind<WinObserver>().AsSingle().NonLazy();
      
    }
  }
}