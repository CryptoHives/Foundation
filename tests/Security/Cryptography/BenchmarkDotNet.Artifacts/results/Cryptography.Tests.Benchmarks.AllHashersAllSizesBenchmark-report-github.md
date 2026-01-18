```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-1265U 2.70GHz, 1 CPU, 12 logical and 10 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                      | TestDataSize | Mean         | Error        | StdDev       | Median       | Allocated |
|------------------------------------------------- |------------- |-------------:|-------------:|-------------:|-------------:|----------:|
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128B         |     250.6 ns |      1.49 ns |      1.32 ns |     250.0 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128B         |     321.0 ns |      3.04 ns |      2.85 ns |     320.8 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128B         |     338.4 ns |      6.80 ns |     12.43 ns |     336.2 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128B         |     381.6 ns |      4.95 ns |      4.63 ns |     380.1 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128B         |     474.1 ns |      2.38 ns |      2.11 ns |     474.1 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 137B         |     576.7 ns |      6.65 ns |      6.22 ns |     575.6 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 137B         |     615.2 ns |     11.22 ns |     20.24 ns |     606.5 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 137B         |     637.8 ns |     12.79 ns |     12.57 ns |     638.0 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 137B         |     786.9 ns |      9.03 ns |      8.00 ns |     786.1 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 137B         |   1,008.9 ns |     11.17 ns |      9.90 ns |   1,008.2 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1KB          |   1,764.2 ns |     23.26 ns |     21.75 ns |   1,761.3 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1KB          |   2,203.2 ns |     39.18 ns |     41.92 ns |   2,178.2 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1KB          |   2,355.3 ns |     44.23 ns |     41.38 ns |   2,335.8 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1KB          |   2,383.4 ns |     35.75 ns |     33.44 ns |   2,397.3 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1KB          |   3,673.4 ns |     68.98 ns |     64.52 ns |   3,677.6 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1025B        |   1,768.4 ns |     19.34 ns |     18.09 ns |   1,770.3 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1025B        |   2,218.3 ns |     30.82 ns |     28.82 ns |   2,213.9 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1025B        |   2,314.9 ns |     31.87 ns |     28.25 ns |   2,306.5 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1025B        |   2,315.6 ns |     19.42 ns |     17.22 ns |   2,317.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1025B        |   3,569.6 ns |     42.95 ns |     38.08 ns |   3,566.1 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 8KB          |  12,872.8 ns |    105.48 ns |     98.67 ns |  12,862.9 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 8KB          |  16,478.6 ns |    310.75 ns |    404.07 ns |  16,293.2 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 8KB          |  17,007.9 ns |    134.37 ns |    112.21 ns |  16,993.2 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 8KB          |  17,201.9 ns |    268.06 ns |    237.63 ns |  17,210.5 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 8KB          |  26,810.2 ns |    501.97 ns |    469.55 ns |  26,670.2 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128KB        | 206,942.5 ns |  3,943.89 ns |  3,293.33 ns | 208,251.5 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128KB        | 270,110.7 ns |  3,201.45 ns |  2,838.00 ns | 269,179.2 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128KB        | 272,230.6 ns |  3,506.84 ns |  2,737.91 ns | 272,073.5 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128KB        | 286,179.1 ns | 10,619.02 ns | 29,069.40 ns | 275,856.5 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128KB        | 439,826.0 ns |  8,332.01 ns | 19,310.71 ns | 436,719.5 ns |     112 B |
