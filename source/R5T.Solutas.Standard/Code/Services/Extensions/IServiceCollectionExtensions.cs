using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Cambridge.Types;
using R5T.Megara.TextSerializer;
using R5T.Solutas.Megara;
using R5T.Solutas.Tiros;


namespace R5T.Solutas.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddVisualStudioSolutionFileSerizlier(this IServiceCollection services)
        {
            services
                .AddSingleton<IVisualStudioSolutionFileSerializer, VisualStudioSolutionFileSerializer>()
                .AddTextFileSerializer<SolutionFile, VisualStudioSolutionFileTextSerializer>()
                ;

            return services;
        }
    }
}
