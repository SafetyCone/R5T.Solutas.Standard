using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Chalandri;
using R5T.Evosmos;
using R5T.Ilioupoli.Default;
using R5T.Liverpool;


namespace R5T.Solutas.Standard.Construction
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var serviceProvider = ServiceProviderServiceBuilder.New().UseStartupAndBuild<Startup>())
            {
                var program = serviceProvider.GetRequiredService<Program>();

                program.Run();
            }
        }


        private ITestingDataDirectoryContentPathsProvider TestingDataDirectoryContentPathsProvider { get; }
        private ITemporaryDirectoryFilePathProvider TemporaryDirectoryFilePathProvider { get; }
        private IVisualStudioSolutionFileSerializer VisualStudioSolutionFileSerializer { get; }


        public Program(
            ITestingDataDirectoryContentPathsProvider testingDataDirectoryContentPathsProvider,
            ITemporaryDirectoryFilePathProvider temporaryDirectoryFilePathProvider,
            IVisualStudioSolutionFileSerializer visualStudioSolutionFileSerializer)
        {
            this.TestingDataDirectoryContentPathsProvider = testingDataDirectoryContentPathsProvider;
            this.TemporaryDirectoryFilePathProvider = temporaryDirectoryFilePathProvider;
            this.VisualStudioSolutionFileSerializer = visualStudioSolutionFileSerializer;
        }

        public void Run()
        {
            var exampleSolutionFilePath = this.TestingDataDirectoryContentPathsProvider.GetExampleVisualStudioSolutionFilePath();

            var solutionFile = this.VisualStudioSolutionFileSerializer.Deserialize(exampleSolutionFilePath);

            var fileName = TestingDataDirectoryContentConventions.ExampleVisualStudioSolutionFileNameValue;
            var outputSolutionFilePath = this.TemporaryDirectoryFilePathProvider.GetTemporaryDirectoryFilePath(fileName);

            this.VisualStudioSolutionFileSerializer.Serialize(outputSolutionFilePath, solutionFile);
        }
    }
}
