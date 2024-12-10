using CodingChallenge;
using CodingChallenge.Dependencies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services.RegisterAppServices())
    .Build();
    
// Default Test File if none specified
// in command line arguments
//
if (args.Length == 0)
{
    args = new[] { Path.Combine("Resources","MainChallengeTestFile.txt") };
}

var entryPoint = host.Services.GetService<MainChallenge>();
if (entryPoint == null) throw new Exception("Could not Resolve Entry Point");

entryPoint.Process(args);
