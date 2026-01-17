```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-1265U 2.70GHz, 1 CPU, 12 logical and 10 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                         | TestDataSize | Mean         | Error        | StdDev       | Median       | Allocated |
|---------------------------------------------------- |------------- |-------------:|-------------:|-------------:|-------------:|----------:|
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar | 128B         |     267.3 ns |      2.99 ns |      2.65 ns |     267.3 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3  | 128B         |     340.5 ns |      5.52 ns |      4.89 ns |     339.4 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle             | 128B         |     366.2 ns |      7.25 ns |     11.28 ns |     370.4 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2   | 128B         |     650.8 ns |      7.25 ns |      6.06 ns |     652.4 ns |     112 B |
|                                                     |              |              |              |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar | 137B         |     599.7 ns |     11.53 ns |     13.72 ns |     599.7 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle             | 137B         |     659.0 ns |     13.02 ns |     18.67 ns |     658.0 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3  | 137B         |     815.0 ns |     11.13 ns |      9.87 ns |     813.3 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2   | 137B         |   1,381.5 ns |     15.47 ns |     14.47 ns |   1,381.6 ns |     112 B |
|                                                     |              |              |              |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar | 1KB          |   2,018.8 ns |     40.27 ns |     47.94 ns |   2,011.6 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle             | 1KB          |   2,678.4 ns |     51.45 ns |    105.09 ns |   2,649.1 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3  | 1KB          |   2,681.1 ns |     47.98 ns |     42.53 ns |   2,688.6 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2   | 1KB          |   5,249.0 ns |    104.93 ns |    234.70 ns |   5,205.7 ns |     112 B |
|                                                     |              |              |              |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar | 1025B        |   1,838.1 ns |     35.21 ns |     43.24 ns |   1,820.2 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle             | 1025B        |   2,286.7 ns |     37.48 ns |     44.62 ns |   2,271.2 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3  | 1025B        |   2,341.1 ns |     25.01 ns |     23.39 ns |   2,341.2 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2   | 1025B        |   4,769.1 ns |     46.02 ns |     38.43 ns |   4,770.4 ns |     112 B |
|                                                     |              |              |              |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar | 8KB          |  13,721.4 ns |    273.53 ns |    681.19 ns |  13,470.6 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3  | 8KB          |  17,279.8 ns |    116.62 ns |    109.09 ns |  17,291.8 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle             | 8KB          |  17,294.4 ns |    343.42 ns |    855.24 ns |  16,887.2 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2   | 8KB          |  35,649.2 ns |    214.39 ns |    190.05 ns |  35,584.0 ns |     112 B |
|                                                     |              |              |              |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar | 128KB        | 207,014.5 ns |  1,718.47 ns |  1,435.00 ns | 206,414.4 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle             | 128KB        | 266,617.6 ns |  5,215.52 ns |  4,355.19 ns | 264,901.0 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3  | 128KB        | 276,411.5 ns |  4,921.04 ns |  4,603.14 ns | 275,828.3 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2   | 128KB        | 577,133.2 ns | 10,515.13 ns | 27,884.63 ns | 565,107.2 ns |     112 B |
