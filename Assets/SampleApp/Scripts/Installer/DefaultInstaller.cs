using SampleApp.Application;
using SampleApp.Domain;
using SampleApp.Infrastructure;
using Zenject;

namespace SampleApp.Installer
{
    public class DefaultInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // ISaveDataRepository �ɂ� JsonSaveDataRepsitory ���g��
            Container
                .Bind<ISaveDataRepository>()
                .To<JsonSaveDataRepsitory>()
                .AsCached();

            Container.Bind<SaveDataService>().AsCached();
        }
    }
}

