```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 128B         |     553.8 ns |     3.01 ns |     2.51 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 128B         |     619.4 ns |     3.08 ns |     2.88 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 128B         |     631.5 ns |     2.52 ns |     2.36 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 137B         |     537.7 ns |     1.75 ns |     1.55 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 137B         |     615.9 ns |     2.62 ns |     2.18 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 137B         |     621.0 ns |     1.83 ns |     1.62 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 1KB          |   2,905.7 ns |    11.08 ns |    10.36 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 1KB          |   3,525.5 ns |    15.71 ns |    13.92 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 1KB          |   3,582.9 ns |    11.48 ns |    10.18 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 1025B        |   2,907.9 ns |     9.58 ns |     8.00 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 1025B        |   3,519.9 ns |    11.67 ns |    10.34 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 1025B        |   3,579.2 ns |     9.68 ns |     8.58 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 8KB          |  17,452.3 ns |    72.19 ns |    60.29 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 8KB          |  22,309.9 ns |    75.66 ns |    70.77 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 8KB          |  23,981.7 ns |    60.80 ns |    53.90 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 128KB        | 275,023.3 ns | 1,136.26 ns | 1,007.27 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 128KB        | 353,151.5 ns | 1,580.21 ns | 1,319.54 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 128KB        | 379,737.4 ns | 1,218.76 ns | 1,140.03 ns |     112 B |
