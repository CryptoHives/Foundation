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
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128B         |     251.5 ns |      2.70 ns |      2.11 ns |     251.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128B         |     320.5 ns |      3.62 ns |      3.21 ns |     319.5 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128B         |     323.3 ns |      3.51 ns |      2.93 ns |     322.7 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128B         |     376.3 ns |      4.09 ns |      3.83 ns |     376.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128B         |     444.7 ns |      3.67 ns |      3.43 ns |     444.6 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 137B         |     549.5 ns |      3.17 ns |      2.48 ns |     549.4 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 137B         |     586.7 ns |     10.63 ns |      9.94 ns |     586.4 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 137B         |     631.0 ns |      7.29 ns |      6.09 ns |     630.3 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 137B         |     752.6 ns |      5.43 ns |      4.81 ns |     753.5 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 137B         |     969.5 ns |     10.40 ns |      9.73 ns |     967.6 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1KB          |   1,789.5 ns |     30.52 ns |     32.65 ns |   1,779.4 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1KB          |   2,182.4 ns |     36.34 ns |     33.99 ns |   2,173.1 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1KB          |   2,290.7 ns |     23.00 ns |     19.21 ns |   2,291.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1KB          |   2,295.6 ns |     33.38 ns |     29.59 ns |   2,285.9 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1KB          |   3,375.2 ns |     67.14 ns |     74.62 ns |   3,368.5 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1025B        |   1,767.0 ns |     16.05 ns |     15.02 ns |   1,766.4 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1025B        |   2,297.8 ns |     18.36 ns |     14.33 ns |   2,293.8 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1025B        |   2,358.8 ns |     47.03 ns |    123.08 ns |   2,306.4 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1025B        |   2,417.3 ns |     89.74 ns |    248.68 ns |   2,344.1 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1025B        |   3,335.6 ns |     63.43 ns |     62.29 ns |   3,314.7 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 8KB          |  13,424.8 ns |    348.26 ns |    993.62 ns |  13,008.5 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 8KB          |  16,876.5 ns |    134.80 ns |    112.57 ns |  16,901.8 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 8KB          |  17,213.5 ns |    337.57 ns |    346.66 ns |  17,056.7 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 8KB          |  24,917.0 ns |    231.25 ns |    216.31 ns |  25,018.3 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 8KB          |  27,554.6 ns |  3,668.04 ns | 10,815.29 ns |  23,554.7 ns |     112 B |
|                                                  |              |              |              |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128KB        | 205,349.0 ns |  3,054.50 ns |  3,395.07 ns | 204,845.7 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128KB        | 264,252.4 ns |  4,836.09 ns |  6,456.04 ns | 263,717.0 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128KB        | 277,204.6 ns |  5,389.38 ns |  7,194.67 ns | 274,660.1 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128KB        | 326,696.2 ns | 24,739.87 ns | 70,983.33 ns | 289,574.9 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128KB        | 396,620.5 ns |  7,081.16 ns |  6,277.27 ns | 396,671.7 ns |     112 B |
