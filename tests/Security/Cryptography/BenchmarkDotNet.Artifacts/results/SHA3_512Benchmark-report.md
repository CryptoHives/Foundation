```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                      | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|------------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| ComputeHash · SHA3-512 · SHA3-512 (Managed)      | 128B         |     810.5 ns |      2.44 ns |      2.03 ns |     176 B |
| ComputeHash · SHA3-512 · SHA3-512 (AVX2)         | 128B         |     988.0 ns |      4.27 ns |      3.57 ns |     176 B |
| ComputeHash · SHA3-512 · SHA3-512 (BouncyCastle) | 128B         |   1,086.8 ns |      2.73 ns |      2.42 ns |     176 B |
|                                                  |              |              |              |              |           |
| ComputeHash · SHA3-512 · SHA3-512 (Managed)      | 137B         |     796.3 ns |      1.93 ns |      1.51 ns |     176 B |
| ComputeHash · SHA3-512 · SHA3-512 (AVX2)         | 137B         |     981.2 ns |      2.68 ns |      2.09 ns |     176 B |
| ComputeHash · SHA3-512 · SHA3-512 (BouncyCastle) | 137B         |   1,082.8 ns |      2.32 ns |      2.06 ns |     176 B |
|                                                  |              |              |              |              |           |
| ComputeHash · SHA3-512 · SHA3-512 (Managed)      | 1KB          |   5,376.8 ns |     15.47 ns |     12.92 ns |     176 B |
| ComputeHash · SHA3-512 · SHA3-512 (AVX2)         | 1KB          |   6,861.0 ns |     22.96 ns |     20.35 ns |     176 B |
| ComputeHash · SHA3-512 · SHA3-512 (BouncyCastle) | 1KB          |   7,239.3 ns |     18.43 ns |     16.34 ns |     176 B |
|                                                  |              |              |              |              |           |
| ComputeHash · SHA3-512 · SHA3-512 (Managed)      | 1025B        |   5,378.9 ns |     22.10 ns |     20.67 ns |     176 B |
| ComputeHash · SHA3-512 · SHA3-512 (AVX2)         | 1025B        |   6,863.4 ns |     21.41 ns |     18.98 ns |     176 B |
| ComputeHash · SHA3-512 · SHA3-512 (BouncyCastle) | 1025B        |   7,243.7 ns |     27.01 ns |     25.27 ns |     176 B |
|                                                  |              |              |              |              |           |
| ComputeHash · SHA3-512 · SHA3-512 (Managed)      | 8KB          |  39,052.6 ns |    142.07 ns |    132.90 ns |     176 B |
| ComputeHash · SHA3-512 · SHA3-512 (AVX2)         | 8KB          |  51,261.9 ns |    177.01 ns |    156.92 ns |     176 B |
| ComputeHash · SHA3-512 · SHA3-512 (BouncyCastle) | 8KB          |  53,810.2 ns |    224.10 ns |    209.63 ns |     176 B |
|                                                  |              |              |              |              |           |
| ComputeHash · SHA3-512 · SHA3-512 (Managed)      | 128KB        | 620,525.6 ns |  3,506.57 ns |  3,108.48 ns |     176 B |
| ComputeHash · SHA3-512 · SHA3-512 (AVX2)         | 128KB        | 808,372.7 ns |  2,830.66 ns |  2,210.00 ns |     176 B |
| ComputeHash · SHA3-512 · SHA3-512 (BouncyCastle) | 128KB        | 865,395.1 ns | 13,827.41 ns | 16,460.55 ns |     176 B |
