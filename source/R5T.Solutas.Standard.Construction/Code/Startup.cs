using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Chalandri.DropboxRivetTestingData;
using R5T.Evosmos.CDriveTemp;
using R5T.Richmond;


namespace R5T.Solutas.Standard.Construction
{
    public class Startup : StartupBase
    {
        public Startup(ILogger<Startup> logger)
            : base(logger)
        {
        }

        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services
                .AddSingleton<Program>()
                .AddVisualStudioSolutionFileSerializer()
                .AddTestingDataDirectoryContentPathsProvider()
                .AddTemporaryDirectoryFilePathProvider()
                ;
        }
    }
}
