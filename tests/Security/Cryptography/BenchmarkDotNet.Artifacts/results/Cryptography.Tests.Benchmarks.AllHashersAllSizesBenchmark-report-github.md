```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-1265U 2.70GHz, 1 CPU, 12 logical and 10 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                      | TestDataSize | Mean         | Error       | StdDev       | Median       | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|-------------:|-------------:|----------:|
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128B         |     254.4 ns |     5.14 ns |      4.55 ns |     253.4 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128B         |     320.1 ns |     2.74 ns |      2.43 ns |     320.4 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128B         |     325.7 ns |     2.86 ns |      2.54 ns |     324.7 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128B         |     380.2 ns |     2.87 ns |      2.40 ns |     380.3 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128B         |     418.3 ns |     1.85 ns |      1.64 ns |     418.4 ns |     112 B |
|                                                  |              |              |             |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 137B         |     553.5 ns |     7.42 ns |      6.58 ns |     551.8 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 137B         |     599.3 ns |    11.77 ns |     16.49 ns |     596.7 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 137B         |     627.9 ns |     3.91 ns |      3.66 ns |     627.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 137B         |     752.6 ns |    14.82 ns |     12.38 ns |     749.5 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 137B         |     923.2 ns |    15.13 ns |     20.71 ns |     920.2 ns |     112 B |
|                                                  |              |              |             |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1KB          |   1,764.8 ns |    21.03 ns |     19.67 ns |   1,761.9 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1KB          |   2,177.5 ns |    17.39 ns |     14.52 ns |   2,174.9 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1KB          |   2,290.8 ns |    24.60 ns |     21.81 ns |   2,287.9 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1KB          |   2,306.2 ns |    37.77 ns |     33.48 ns |   2,301.3 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1KB          |   3,142.7 ns |    60.55 ns |     59.47 ns |   3,136.7 ns |     112 B |
|                                                  |              |              |             |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1025B        |   1,772.9 ns |    33.77 ns |     37.53 ns |   1,757.6 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1025B        |   2,193.4 ns |    23.02 ns |     19.22 ns |   2,191.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1025B        |   2,323.5 ns |    42.16 ns |     39.44 ns |   2,312.9 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1025B        |   2,370.3 ns |    45.12 ns |     55.41 ns |   2,357.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1025B        |   3,129.9 ns |    55.36 ns |     46.23 ns |   3,132.4 ns |     112 B |
|                                                  |              |              |             |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 8KB          |  12,981.0 ns |   218.33 ns |    193.55 ns |  13,017.3 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 8KB          |  16,234.8 ns |   149.78 ns |    125.07 ns |  16,193.9 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 8KB          |  16,956.3 ns |   156.45 ns |    146.35 ns |  16,956.6 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 8KB          |  17,204.2 ns |   334.36 ns |    312.76 ns |  17,156.7 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 8KB          |  23,535.0 ns |   397.01 ns |    371.37 ns |  23,456.6 ns |     112 B |
|                                                  |              |              |             |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128KB        | 205,918.4 ns | 2,872.78 ns |  3,633.15 ns | 204,864.5 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128KB        | 266,068.6 ns | 1,962.03 ns |  1,638.39 ns | 266,203.7 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128KB        | 270,248.3 ns | 3,629.41 ns |  3,217.37 ns | 269,326.7 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128KB        | 272,002.8 ns | 5,628.68 ns | 15,783.43 ns | 267,620.1 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128KB        | 368,196.8 ns | 5,273.47 ns |  4,932.81 ns | 366,372.0 ns |     112 B |
