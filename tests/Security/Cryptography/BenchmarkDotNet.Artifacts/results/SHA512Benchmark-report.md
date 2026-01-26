```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHA-512 · SHA-512 (OS)           | 128B         |     804.0 ns |     5.04 ns |     4.21 ns |     176 B |
| ComputeHash · SHA-512 · SHA-512 (BouncyCastle) | 128B         |     842.0 ns |     2.30 ns |     2.15 ns |     176 B |
| ComputeHash · SHA-512 · SHA-512 (Managed)      | 128B         |     945.0 ns |     3.52 ns |     2.94 ns |     176 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-512 · SHA-512 (OS)           | 137B         |     810.0 ns |     9.61 ns |     9.44 ns |     176 B |
| ComputeHash · SHA-512 · SHA-512 (BouncyCastle) | 137B         |     848.7 ns |     1.79 ns |     1.58 ns |     176 B |
| ComputeHash · SHA-512 · SHA-512 (Managed)      | 137B         |     939.8 ns |     5.27 ns |     4.68 ns |     176 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-512 · SHA-512 (OS)           | 1KB          |   2,970.8 ns |    12.57 ns |    11.14 ns |     176 B |
| ComputeHash · SHA-512 · SHA-512 (BouncyCastle) | 1KB          |   3,437.1 ns |    15.19 ns |    11.86 ns |     176 B |
| ComputeHash · SHA-512 · SHA-512 (Managed)      | 1KB          |   3,762.6 ns |    12.16 ns |    10.78 ns |     176 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-512 · SHA-512 (OS)           | 1025B        |   2,974.2 ns |    11.47 ns |    10.73 ns |     176 B |
| ComputeHash · SHA-512 · SHA-512 (BouncyCastle) | 1025B        |   3,426.4 ns |    15.96 ns |    13.33 ns |     176 B |
| ComputeHash · SHA-512 · SHA-512 (Managed)      | 1025B        |   3,761.5 ns |    12.49 ns |    11.68 ns |     176 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-512 · SHA-512 (OS)           | 8KB          |  19,693.6 ns |    85.04 ns |    79.55 ns |     176 B |
| ComputeHash · SHA-512 · SHA-512 (BouncyCastle) | 8KB          |  23,982.2 ns |   102.06 ns |    90.47 ns |     176 B |
| ComputeHash · SHA-512 · SHA-512 (Managed)      | 8KB          |  26,227.7 ns |    68.56 ns |    60.77 ns |     176 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-512 · SHA-512 (OS)           | 128KB        | 306,888.9 ns |   807.27 ns |   715.62 ns |     176 B |
| ComputeHash · SHA-512 · SHA-512 (BouncyCastle) | 128KB        | 375,393.1 ns | 1,068.88 ns |   947.53 ns |     176 B |
| ComputeHash · SHA-512 · SHA-512 (Managed)      | 128KB        | 412,049.5 ns | 2,040.80 ns | 1,908.96 ns |     176 B |
