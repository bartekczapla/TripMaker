using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TripMaker.Configuration;

namespace TripMaker.Web.Host.Startup
{
    [DependsOn(
       typeof(TripMakerWebCoreModule))]
    public class TripMakerWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TripMakerWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TripMakerWebHostModule).GetAssembly());
        }
    }
}
