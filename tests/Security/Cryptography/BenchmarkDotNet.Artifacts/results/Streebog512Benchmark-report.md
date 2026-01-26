```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                              | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| ComputeHash · Streebog-512 · Streebog-512 (Managed)      | 128B         |     3.331 μs |  0.0118 μs |  0.0110 μs |     176 B |
| ComputeHash · Streebog-512 · Streebog-512 (OpenGost)     | 128B         |     5.622 μs |  0.0124 μs |  0.0104 μs |     264 B |
| ComputeHash · Streebog-512 · Streebog-512 (BouncyCastle) | 128B         |     8.053 μs |  0.0258 μs |  0.0215 μs |     176 B |
|                                                          |              |              |            |            |           |
| ComputeHash · Streebog-512 · Streebog-512 (Managed)      | 137B         |     3.281 μs |  0.0135 μs |  0.0120 μs |     176 B |
| ComputeHash · Streebog-512 · Streebog-512 (OpenGost)     | 137B         |     5.632 μs |  0.0111 μs |  0.0087 μs |     264 B |
| ComputeHash · Streebog-512 · Streebog-512 (BouncyCastle) | 137B         |     8.022 μs |  0.0214 μs |  0.0179 μs |     176 B |
|                                                          |              |              |            |            |           |
| ComputeHash · Streebog-512 · Streebog-512 (Managed)      | 1KB          |    12.166 μs |  0.0546 μs |  0.0484 μs |     176 B |
| ComputeHash · Streebog-512 · Streebog-512 (OpenGost)     | 1KB          |    21.172 μs |  0.0698 μs |  0.0619 μs |     264 B |
| ComputeHash · Streebog-512 · Streebog-512 (BouncyCastle) | 1KB          |    30.641 μs |  0.1064 μs |  0.0943 μs |     176 B |
|                                                          |              |              |            |            |           |
| ComputeHash · Streebog-512 · Streebog-512 (Managed)      | 1025B        |    12.151 μs |  0.0396 μs |  0.0309 μs |     176 B |
| ComputeHash · Streebog-512 · Streebog-512 (OpenGost)     | 1025B        |    21.161 μs |  0.0915 μs |  0.0856 μs |     264 B |
| ComputeHash · Streebog-512 · Streebog-512 (BouncyCastle) | 1025B        |    30.756 μs |  0.0634 μs |  0.0530 μs |     176 B |
|                                                          |              |              |            |            |           |
| ComputeHash · Streebog-512 · Streebog-512 (Managed)      | 8KB          |    83.791 μs |  0.3292 μs |  0.2918 μs |     176 B |
| ComputeHash · Streebog-512 · Streebog-512 (OpenGost)     | 8KB          |   144.625 μs |  0.2873 μs |  0.2399 μs |     264 B |
| ComputeHash · Streebog-512 · Streebog-512 (BouncyCastle) | 8KB          |   210.849 μs |  0.5192 μs |  0.4054 μs |     176 B |
|                                                          |              |              |            |            |           |
| ComputeHash · Streebog-512 · Streebog-512 (Managed)      | 128KB        | 1,348.377 μs | 10.4352 μs |  8.7139 μs |     176 B |
| ComputeHash · Streebog-512 · Streebog-512 (OpenGost)     | 128KB        | 2,260.552 μs |  6.3525 μs |  5.6314 μs |     264 B |
| ComputeHash · Streebog-512 · Streebog-512 (BouncyCastle) | 128KB        | 3,282.703 μs | 14.4072 μs | 12.0307 μs |     176 B |
