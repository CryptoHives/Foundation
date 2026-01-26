```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                                | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128B         |     1.303 μs | 0.0062 μs | 0.0055 μs |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128B         |     1.468 μs | 0.0054 μs | 0.0054 μs |     112 B |
|                                                            |              |              |           |           |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 137B         |     1.429 μs | 0.0054 μs | 0.0048 μs |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 137B         |     1.510 μs | 0.0079 μs | 0.0066 μs |     112 B |
|                                                            |              |              |           |           |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1KB          |     8.160 μs | 0.0389 μs | 0.0345 μs |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1KB          |     8.638 μs | 0.0364 μs | 0.0322 μs |     112 B |
|                                                            |              |              |           |           |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1025B        |     8.156 μs | 0.0436 μs | 0.0387 μs |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1025B        |     8.921 μs | 0.0710 μs | 0.0554 μs |     112 B |
|                                                            |              |              |           |           |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 8KB          |    62.466 μs | 0.2041 μs | 0.1705 μs |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 8KB          |    65.989 μs | 0.3309 μs | 0.2763 μs |     112 B |
|                                                            |              |              |           |           |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128KB        |   999.232 μs | 3.5304 μs | 2.9480 μs |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128KB        | 1,052.268 μs | 4.5726 μs | 3.8183 μs |     112 B |
