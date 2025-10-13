// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

static class Program
{
    // Main Method 
    public static void Main(string[] args)
    {
        IConfig config = ManualConfig.Create(DefaultConfig.Instance)
            // need this option because of reference to nunit.framework
            .WithOptions(ConfigOptions.DisableOptimizationsValidator)
            ;
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
    }
}

