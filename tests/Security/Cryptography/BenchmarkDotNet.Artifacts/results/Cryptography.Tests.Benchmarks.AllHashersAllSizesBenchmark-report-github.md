```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-1265U 2.70GHz, 1 CPU, 12 logical and 10 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                      | TestDataSize | Mean         | Error        | StdDev        | Median       | Allocated |
|------------------------------------------------- |------------- |-------------:|-------------:|--------------:|-------------:|----------:|
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128B         |     264.6 ns |      5.29 ns |       7.75 ns |     261.5 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128B         |     336.7 ns |      6.40 ns |       8.10 ns |     334.4 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128B         |     349.0 ns |      6.97 ns |      13.26 ns |     344.5 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128B         |     387.3 ns |      3.67 ns |       3.43 ns |     385.9 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128B         |     686.5 ns |      9.71 ns |       8.61 ns |     685.0 ns |     112 B |
|                                                  |              |              |              |               |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 137B         |     588.3 ns |     11.83 ns |      19.10 ns |     582.1 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 137B         |     629.9 ns |     12.53 ns |      27.77 ns |     615.1 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 137B         |     659.5 ns |     12.96 ns |      11.49 ns |     655.2 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 137B         |     778.0 ns |     14.99 ns |      12.52 ns |     773.7 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 137B         |   1,431.0 ns |     28.36 ns |      53.27 ns |   1,403.7 ns |     112 B |
|                                                  |              |              |              |               |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1KB          |   1,859.1 ns |     36.92 ns |      57.48 ns |   1,836.7 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1KB          |   2,303.7 ns |     46.04 ns |      43.07 ns |   2,284.0 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1KB          |   2,379.7 ns |     27.09 ns |      22.62 ns |   2,385.0 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1KB          |   2,392.7 ns |     41.04 ns |      36.38 ns |   2,383.0 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1KB          |   5,107.2 ns |     57.60 ns |      48.10 ns |   5,105.9 ns |     112 B |
|                                                  |              |              |              |               |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 1025B        |   1,870.4 ns |     36.96 ns |      64.73 ns |   1,848.0 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 1025B        |   2,456.1 ns |     66.75 ns |     187.17 ns |   2,392.4 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 1025B        |   2,474.5 ns |     47.38 ns |      56.40 ns |   2,474.0 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 1025B        |   2,699.8 ns |    107.36 ns |     302.82 ns |   2,596.8 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 1025B        |   5,569.3 ns |    183.59 ns |     523.80 ns |   5,348.5 ns |     112 B |
|                                                  |              |              |              |               |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 8KB          |  13,632.9 ns |    261.01 ns |     339.39 ns |  13,533.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 8KB          |  17,676.0 ns |    287.93 ns |     255.25 ns |  17,615.4 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 8KB          |  17,734.0 ns |    305.51 ns |     270.82 ns |  17,684.1 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 8KB          |  17,824.2 ns |    390.54 ns |   1,075.65 ns |  17,462.7 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 8KB          |  38,698.5 ns |    640.30 ns |     567.61 ns |  38,523.9 ns |     112 B |
|                                                  |              |              |              |               |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar | 128KB        | 283,734.4 ns | 20,178.70 ns |  58,542.08 ns | 276,609.8 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native               | 128KB        | 314,356.5 ns | 16,732.49 ns |  47,467.30 ns | 290,615.7 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3  | 128KB        | 334,382.4 ns | 21,498.97 ns |  61,684.57 ns | 313,417.6 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle            | 128KB        | 429,742.0 ns | 65,031.74 ns | 191,747.56 ns | 313,213.9 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2   | 128KB        | 800,842.3 ns | 59,284.87 ns | 173,872.28 ns | 758,053.5 ns |     112 B |
