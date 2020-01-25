using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Cambridge.Types;
using R5T.Megara.TextSerializer;
using R5T.Stockholm.Default;
using R5T.Solutas.Megara;
using R5T.Solutas.Tiros;


namespace R5T.Solutas.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds an <see cref="IVisualStudioSolutionFileSerializer"/> service.
        /// </summary>
        public static IServiceCollection AddVisualStudioSolutionFileSerializer(this IServiceCollection services)
        {
            services
                .AddSingleton<IVisualStudioSolutionFileSerializer, VisualStudioSolutionFileSerializer>()
                .AddTextFileSerializer<SolutionFile, VisualStudioSolutionFileTextSerializer>()
                // Configue stream serializer options to use a byte-order-mark for Visual Studio solution files.
                .Configure<StreamSerializerOptions<SolutionFile>>(options =>
                {
                    options.AddByteOrderMark = true;
                })
                ;

            return services;
        }
    }
}
