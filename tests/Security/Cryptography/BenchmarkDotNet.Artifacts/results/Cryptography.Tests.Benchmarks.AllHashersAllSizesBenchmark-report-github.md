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
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128B         |     253.1 ns |      4.71 ns |      4.40 ns |     252.7 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128B         |     321.3 ns |      3.00 ns |      2.66 ns |     320.2 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128B         |     324.7 ns |      6.07 ns |      5.38 ns |     322.1 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128B         |     380.7 ns |      3.60 ns |      3.37 ns |     379.8 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128B         |     449.4 ns |      7.26 ns |      6.79 ns |     448.1 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 137B         |     557.0 ns |      6.20 ns |      5.80 ns |     556.1 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 137B         |     594.0 ns |     11.69 ns |     14.36 ns |     591.9 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 137B         |     628.8 ns |      4.59 ns |      4.07 ns |     628.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 137B         |     751.7 ns |      7.43 ns |      6.95 ns |     751.0 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 137B         |     956.5 ns |      7.87 ns |      6.57 ns |     958.4 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1KB          |   1,746.6 ns |     11.25 ns |      9.97 ns |   1,748.6 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1KB          |   2,178.5 ns |     16.42 ns |     13.71 ns |   2,175.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1KB          |   2,292.9 ns |     16.58 ns |     15.51 ns |   2,295.4 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1KB          |   2,324.7 ns |     34.35 ns |     32.14 ns |   2,319.8 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1KB          |   3,310.4 ns |     17.14 ns |     16.03 ns |   3,304.6 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1025B        |   1,794.3 ns |     35.44 ns |     46.08 ns |   1,786.0 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1025B        |   2,292.9 ns |     16.07 ns |     14.24 ns |   2,290.6 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1025B        |   2,295.0 ns |     45.88 ns |    107.25 ns |   2,261.0 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1025B        |   2,303.4 ns |     20.34 ns |     19.02 ns |   2,300.9 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1025B        |   3,404.8 ns |     47.52 ns |     44.45 ns |   3,415.5 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 8KB          |  15,341.2 ns |  1,028.94 ns |  3,017.70 ns |  13,638.5 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 8KB          |  16,854.3 ns |    140.41 ns |    117.25 ns |  16,848.0 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 8KB          |  16,966.6 ns |    184.13 ns |    163.23 ns |  16,922.4 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 8KB          |  21,403.6 ns |  1,897.86 ns |  5,566.09 ns |  18,860.4 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 8KB          |  24,660.5 ns |    187.81 ns |    156.83 ns |  24,693.2 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128KB        | 202,550.8 ns |  3,227.67 ns |  2,861.25 ns | 201,754.4 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128KB        | 268,441.4 ns |  3,561.91 ns |  3,959.05 ns | 266,986.8 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128KB        | 269,023.2 ns |  2,677.91 ns |  2,373.90 ns | 268,386.3 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128KB        | 281,634.4 ns | 12,890.78 ns | 35,288.30 ns | 268,520.5 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128KB        | 386,216.0 ns |  1,704.53 ns |  1,423.36 ns | 386,094.3 ns |     112 B |
