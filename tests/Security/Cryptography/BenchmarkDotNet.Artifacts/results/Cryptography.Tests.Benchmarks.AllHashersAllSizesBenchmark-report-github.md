```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-1265U 2.70GHz, 1 CPU, 12 logical and 10 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128B         |     252.0 ns |     3.42 ns |     2.86 ns |     251.3 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128B         |     331.0 ns |     4.06 ns |     3.79 ns |     330.8 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128B         |     339.8 ns |     3.51 ns |     2.93 ns |     339.8 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128B         |     393.3 ns |     7.75 ns |     9.23 ns |     395.2 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128B         |     496.6 ns |     6.70 ns |     6.27 ns |     494.7 ns |     112 B |
|                                                  |              |              |             |             |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 137B         |     570.5 ns |     7.16 ns |     6.70 ns |     571.3 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 137B         |     619.2 ns |    12.29 ns |    20.19 ns |     615.7 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 137B         |     660.6 ns |     9.08 ns |     8.05 ns |     657.4 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 137B         |     786.5 ns |    10.13 ns |     8.46 ns |     784.7 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 137B         |   1,061.6 ns |     8.01 ns |     7.10 ns |   1,062.2 ns |     112 B |
|                                                  |              |              |             |             |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1KB          |   1,751.7 ns |    10.50 ns |     8.77 ns |   1,750.3 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1KB          |   2,282.3 ns |    45.49 ns |   109.00 ns |   2,241.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1KB          |   2,299.6 ns |    28.74 ns |    24.00 ns |   2,291.8 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1KB          |   2,330.2 ns |    46.19 ns |    38.57 ns |   2,319.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1KB          |   3,759.8 ns |    64.50 ns |    57.18 ns |   3,763.0 ns |     112 B |
|                                                  |              |              |             |             |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1025B        |   1,752.3 ns |    14.77 ns |    12.34 ns |   1,748.7 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1025B        |   2,183.2 ns |    42.00 ns |    44.94 ns |   2,167.7 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1025B        |   2,301.8 ns |    21.38 ns |    18.95 ns |   2,301.4 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1025B        |   2,308.2 ns |    37.49 ns |    33.23 ns |   2,297.2 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1025B        |   3,702.1 ns |    26.47 ns |    22.10 ns |   3,705.0 ns |     112 B |
|                                                  |              |              |             |             |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 8KB          |  12,800.8 ns |    80.06 ns |    74.89 ns |  12,802.6 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 8KB          |  16,069.3 ns |   193.48 ns |   171.51 ns |  16,001.7 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 8KB          |  16,872.7 ns |   103.41 ns |    96.73 ns |  16,861.4 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 8KB          |  16,971.9 ns |   121.17 ns |   107.41 ns |  16,961.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 8KB          |  27,606.2 ns |   316.27 ns |   295.84 ns |  27,492.4 ns |     112 B |
|                                                  |              |              |             |             |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128KB        | 202,030.2 ns | 2,933.17 ns | 2,449.33 ns | 201,713.2 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128KB        | 253,355.1 ns | 3,210.16 ns | 2,680.63 ns | 252,762.5 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128KB        | 266,163.9 ns | 1,877.63 ns | 1,756.34 ns | 266,026.7 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128KB        | 267,643.6 ns | 2,797.09 ns | 2,479.55 ns | 267,377.8 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128KB        | 433,668.1 ns | 4,198.14 ns | 3,277.63 ns | 432,795.5 ns |     112 B |
