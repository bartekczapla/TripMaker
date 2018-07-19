using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TripMaker.Authorization;

namespace TripMaker
{
    [DependsOn(
        typeof(TripMakerCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TripMakerApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TripMakerAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TripMakerApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
