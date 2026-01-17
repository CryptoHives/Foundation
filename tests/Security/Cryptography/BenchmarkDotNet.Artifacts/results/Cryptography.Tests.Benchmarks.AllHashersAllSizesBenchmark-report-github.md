```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-1265U 2.70GHz, 1 CPU, 12 logical and 10 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                         | TestDataSize | Mean         | Error        | StdDev        | Median       | Allocated |
|---------------------------------------------------- |------------- |-------------:|-------------:|--------------:|-------------:|----------:|
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar | 128B         |     272.9 ns |      5.37 ns |       6.39 ns |     271.8 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3  | 128B         |     346.3 ns |      4.89 ns |       5.82 ns |     345.1 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle             | 128B         |     363.9 ns |      7.32 ns |      16.67 ns |     358.2 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2   | 128B         |     797.8 ns |      7.50 ns |       6.26 ns |     799.9 ns |     112 B |
|                                                     |              |              |              |               |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar | 137B         |     599.3 ns |     11.95 ns |      21.55 ns |     589.2 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle             | 137B         |     652.7 ns |     13.12 ns |      32.19 ns |     643.6 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3  | 137B         |     826.3 ns |     16.26 ns |      33.59 ns |     816.7 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2   | 137B         |   1,653.2 ns |     13.64 ns |      10.65 ns |   1,649.9 ns |     112 B |
|                                                     |              |              |              |               |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar | 1KB          |   1,920.5 ns |     38.02 ns |      58.06 ns |   1,902.8 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3  | 1KB          |   2,452.8 ns |     46.07 ns |      40.84 ns |   2,449.2 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle             | 1KB          |   2,643.9 ns |     92.51 ns |     254.80 ns |   2,601.3 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2   | 1KB          |   6,062.2 ns |    119.68 ns |     122.90 ns |   6,020.3 ns |     112 B |
|                                                     |              |              |              |               |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar | 1025B        |   1,932.8 ns |     38.33 ns |      45.63 ns |   1,916.6 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle             | 1025B        |   2,458.3 ns |     49.13 ns |     140.17 ns |   2,413.5 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3  | 1025B        |   2,586.7 ns |     51.08 ns |     114.24 ns |   2,544.5 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2   | 1025B        |   6,399.4 ns |    119.65 ns |     236.18 ns |   6,326.3 ns |     112 B |
|                                                     |              |              |              |               |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar | 8KB          |  14,065.5 ns |    274.26 ns |     326.48 ns |  14,063.5 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle             | 8KB          |  17,836.0 ns |    291.13 ns |     272.33 ns |  17,846.1 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3  | 8KB          |  18,107.8 ns |    229.73 ns |     273.47 ns |  18,071.6 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2   | 8KB          |  44,710.7 ns |    509.74 ns |     425.66 ns |  44,788.3 ns |     112 B |
|                                                     |              |              |              |               |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar | 128KB        | 224,350.6 ns |  4,118.62 ns |   6,412.20 ns | 221,757.7 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle             | 128KB        | 317,801.0 ns | 15,342.00 ns |  43,771.58 ns | 299,556.5 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3  | 128KB        | 318,211.0 ns | 13,238.50 ns |  37,122.18 ns | 301,019.8 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2   | 128KB        | 834,023.4 ns | 44,308.64 ns | 127,840.56 ns | 772,131.2 ns |     112 B |
