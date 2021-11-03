using Logic;
using Zenject;

namespace Installer
{
  public class SceneInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<SceneRegistrar>().AsSingle().NonLazy();
    }
  }
}