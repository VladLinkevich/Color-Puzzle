using ColorBox;
using Logic;
using SVG;
using Zenject;

namespace Installer
{
  public class SceneInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<SceneRegistrar>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<LevelLoader>().AsSingle().NonLazy();
      
      Container.Bind<ColorBoxPainter>().AsSingle().NonLazy();
      Container.Bind<WinObserver>().AsSingle().NonLazy();
      
      Container.Bind<IColorBoxFactory>().To<ColorBoxFactory>().AsSingle().NonLazy();
      Container.Bind<ISVGParser>().To<IsvgParser>().AsSingle().NonLazy();

    }
  }
}