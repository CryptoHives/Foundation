```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                              | TestDataSize | Mean         | Error      | StdDev    | Allocated |
|--------------------------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|
| ComputeHash · Streebog-256 · Streebog-256 (Managed)      | 128B         |     3.309 μs |  0.0122 μs | 0.0108 μs |     112 B |
| ComputeHash · Streebog-256 · Streebog-256 (OpenGost)     | 128B         |     5.805 μs |  0.0234 μs | 0.0219 μs |     464 B |
| ComputeHash · Streebog-256 · Streebog-256 (BouncyCastle) | 128B         |     8.024 μs |  0.0313 μs | 0.0261 μs |     200 B |
|                                                          |              |              |            |           |           |
| ComputeHash · Streebog-256 · Streebog-256 (Managed)      | 137B         |     3.262 μs |  0.0072 μs | 0.0064 μs |     112 B |
| ComputeHash · Streebog-256 · Streebog-256 (OpenGost)     | 137B         |     5.819 μs |  0.0197 μs | 0.0185 μs |     464 B |
| ComputeHash · Streebog-256 · Streebog-256 (BouncyCastle) | 137B         |     8.013 μs |  0.0161 μs | 0.0135 μs |     200 B |
|                                                          |              |              |            |           |           |
| ComputeHash · Streebog-256 · Streebog-256 (Managed)      | 1KB          |    12.336 μs |  0.0523 μs | 0.0464 μs |     112 B |
| ComputeHash · Streebog-256 · Streebog-256 (OpenGost)     | 1KB          |    21.292 μs |  0.1014 μs | 0.0847 μs |     464 B |
| ComputeHash · Streebog-256 · Streebog-256 (BouncyCastle) | 1KB          |    30.809 μs |  0.1669 μs | 0.1561 μs |     200 B |
|                                                          |              |              |            |           |           |
| ComputeHash · Streebog-256 · Streebog-256 (Managed)      | 1025B        |    12.076 μs |  0.0544 μs | 0.0508 μs |     112 B |
| ComputeHash · Streebog-256 · Streebog-256 (OpenGost)     | 1025B        |    21.315 μs |  0.0692 μs | 0.0613 μs |     464 B |
| ComputeHash · Streebog-256 · Streebog-256 (BouncyCastle) | 1025B        |    31.072 μs |  0.0968 μs | 0.0906 μs |     200 B |
|                                                          |              |              |            |           |           |
| ComputeHash · Streebog-256 · Streebog-256 (Managed)      | 8KB          |    83.849 μs |  0.2873 μs | 0.2687 μs |     112 B |
| ComputeHash · Streebog-256 · Streebog-256 (OpenGost)     | 8KB          |   145.538 μs |  0.5432 μs | 0.5081 μs |     464 B |
| ComputeHash · Streebog-256 · Streebog-256 (BouncyCastle) | 8KB          |   209.561 μs |  0.9797 μs | 0.8685 μs |     200 B |
|                                                          |              |              |            |           |           |
| ComputeHash · Streebog-256 · Streebog-256 (Managed)      | 128KB        | 1,352.394 μs |  4.9174 μs | 4.5998 μs |     112 B |
| ComputeHash · Streebog-256 · Streebog-256 (OpenGost)     | 128KB        | 2,260.648 μs |  9.9276 μs | 9.2863 μs |     464 B |
| ComputeHash · Streebog-256 · Streebog-256 (BouncyCastle) | 128KB        | 3,279.999 μs | 10.1237 μs | 8.4538 μs |     200 B |
