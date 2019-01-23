using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using System.Reflection;

namespace TripMaker.ExternalServices
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class TripMakerExternalServicesModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TripMakerExternalServicesModule).GetAssembly());
        }
    }
}
