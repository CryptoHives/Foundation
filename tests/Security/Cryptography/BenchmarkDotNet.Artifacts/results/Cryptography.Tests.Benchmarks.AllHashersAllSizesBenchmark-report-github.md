```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-1265U 2.70GHz, 1 CPU, 12 logical and 10 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128B         |     257.6 ns |     5.09 ns |     5.86 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128B         |     327.4 ns |     5.84 ns |     5.74 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128B         |     330.6 ns |     5.29 ns |     6.88 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128B         |     396.1 ns |     4.07 ns |     3.60 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128B         |     577.9 ns |    11.31 ns |    18.90 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 137B         |     551.2 ns |     5.00 ns |     4.43 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 137B         |     592.4 ns |    11.49 ns |    14.11 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 137B         |     636.2 ns |     8.90 ns |     8.33 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 137B         |     761.3 ns |    14.73 ns |    13.05 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 137B         |   1,173.4 ns |    11.80 ns |    10.46 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1KB          |   1,763.8 ns |    14.96 ns |    13.27 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1KB          |   2,179.2 ns |    28.63 ns |    23.91 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1KB          |   2,293.1 ns |    15.47 ns |    12.92 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1KB          |   2,311.0 ns |    29.52 ns |    24.65 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1KB          |   4,256.1 ns |    75.13 ns |    66.60 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1025B        |   1,775.2 ns |    30.85 ns |    28.86 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1025B        |   2,207.9 ns |    43.54 ns |    42.76 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1025B        |   2,301.9 ns |    15.04 ns |    12.56 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1025B        |   2,326.2 ns |    43.65 ns |    42.87 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1025B        |   4,249.9 ns |    66.65 ns |    74.08 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 8KB          |  13,357.1 ns |   171.67 ns |   160.58 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 8KB          |  16,973.2 ns |   338.03 ns |   331.99 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 8KB          |  17,186.8 ns |   313.55 ns |   261.83 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 8KB          |  17,507.6 ns |   309.55 ns |   356.48 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 8KB          |  32,065.7 ns |   423.77 ns |   375.66 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128KB        | 201,985.7 ns | 2,474.93 ns | 1,932.27 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128KB        | 261,210.7 ns | 5,218.74 ns | 7,811.16 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128KB        | 267,374.5 ns | 3,098.66 ns | 2,746.88 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128KB        | 277,090.8 ns | 3,733.57 ns | 3,492.38 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128KB        | 518,148.7 ns | 7,686.16 ns | 7,189.64 ns |     112 B |
