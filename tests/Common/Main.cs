

using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

static class Program
{
    // Main Method 
    public static void Main(String[] args)
    {
        IConfig config = ManualConfig.Create(DefaultConfig.Instance)
            // need this option because of reference to nunit.framework
            .WithOptions(ConfigOptions.DisableOptimizationsValidator)
            ;
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
    }
}

