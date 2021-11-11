using ColorBox;
using Logic;
using Logic.GameState;
using SVG;
using Zenject;

namespace Installer
{
  public class SceneInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<GameBootstrapper>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<ColorBoxPainter>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<WinObserver>().AsSingle().NonLazy();

      Container.Bind<GameStateMachine>().AsSingle();

      Container.Bind<StartGameState>().AsSingle().NonLazy();
      Container.Bind<GameLoopState>().AsSingle().NonLazy();
      Container.Bind<WinState>().AsSingle().NonLazy();
      
      Container.Bind<ILevelLoader>().To<LevelLoader>().AsSingle().NonLazy();
      Container.Bind<IColorBoxFactory>().To<ColorBoxFactory>().AsSingle().NonLazy();
      Container.Bind<INeighborFinder>().To<NeighborFinder>().AsSingle().NonLazy();
      Container.Bind<ISVGParser>().To<SVGParser>().AsSingle().NonLazy();

    }
  }
}