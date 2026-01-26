```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (BouncyCastle) | 128B         |     1.285 μs | 0.0058 μs | 0.0054 μs |     112 B |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (Managed)      | 128B         |     1.503 μs | 0.0068 μs | 0.0061 μs |     112 B |
|                                                          |              |              |           |           |           |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (BouncyCastle) | 137B         |     1.356 μs | 0.0051 μs | 0.0045 μs |     112 B |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (Managed)      | 137B         |     1.579 μs | 0.0071 μs | 0.0067 μs |     112 B |
|                                                          |              |              |           |           |           |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (BouncyCastle) | 1KB          |     8.048 μs | 0.0470 μs | 0.0367 μs |     112 B |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (Managed)      | 1KB          |     8.702 μs | 0.0556 μs | 0.0465 μs |     112 B |
|                                                          |              |              |           |           |           |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (BouncyCastle) | 1025B        |     8.039 μs | 0.0230 μs | 0.0192 μs |     112 B |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (Managed)      | 1025B        |     8.703 μs | 0.0468 μs | 0.0438 μs |     112 B |
|                                                          |              |              |           |           |           |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (BouncyCastle) | 8KB          |    61.616 μs | 0.2156 μs | 0.1911 μs |     112 B |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (Managed)      | 8KB          |    66.027 μs | 0.2258 μs | 0.2001 μs |     112 B |
|                                                          |              |              |           |           |           |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (BouncyCastle) | 128KB        |   983.493 μs | 5.6323 μs | 4.7032 μs |     112 B |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (Managed)      | 128KB        | 1,051.105 μs | 3.9145 μs | 3.2688 μs |     112 B |
