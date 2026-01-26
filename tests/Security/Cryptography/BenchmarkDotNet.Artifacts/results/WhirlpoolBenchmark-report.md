```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| ComputeHash · Whirlpool · Whirlpool (Managed)      | 128B         |     2.420 μs |  0.0078 μs |  0.0073 μs |     176 B |
| ComputeHash · Whirlpool · Whirlpool (HashifyNET)   | 128B         |     3.890 μs |  0.0199 μs |  0.0186 μs |    6424 B |
| ComputeHash · Whirlpool · Whirlpool (BouncyCastle) | 128B         |     9.840 μs |  0.0494 μs |  0.0438 μs |     232 B |
|                                                    |              |              |            |            |           |
| ComputeHash · Whirlpool · Whirlpool (Managed)      | 137B         |     2.449 μs |  0.0456 μs |  0.0426 μs |     176 B |
| ComputeHash · Whirlpool · Whirlpool (HashifyNET)   | 137B         |     3.895 μs |  0.0139 μs |  0.0116 μs |    6416 B |
| ComputeHash · Whirlpool · Whirlpool (BouncyCastle) | 137B         |     9.681 μs |  0.0197 μs |  0.0164 μs |     232 B |
|                                                    |              |              |            |            |           |
| ComputeHash · Whirlpool · Whirlpool (Managed)      | 1KB          |    13.162 μs |  0.0420 μs |  0.0372 μs |     176 B |
| ComputeHash · Whirlpool · Whirlpool (HashifyNET)   | 1KB          |    19.212 μs |  0.0640 μs |  0.0500 μs |   12120 B |
| ComputeHash · Whirlpool · Whirlpool (BouncyCastle) | 1KB          |    59.449 μs |  0.1531 μs |  0.1278 μs |     232 B |
|                                                    |              |              |            |            |           |
| ComputeHash · Whirlpool · Whirlpool (Managed)      | 1025B        |    13.166 μs |  0.0385 μs |  0.0321 μs |     176 B |
| ComputeHash · Whirlpool · Whirlpool (HashifyNET)   | 1025B        |    19.198 μs |  0.0716 μs |  0.0597 μs |   12128 B |
| ComputeHash · Whirlpool · Whirlpool (BouncyCastle) | 1025B        |    58.796 μs |  0.1663 μs |  0.1474 μs |     232 B |
|                                                    |              |              |            |            |           |
| ComputeHash · Whirlpool · Whirlpool (Managed)      | 8KB          |    98.741 μs |  0.4313 μs |  0.3368 μs |     176 B |
| ComputeHash · Whirlpool · Whirlpool (HashifyNET)   | 8KB          |   141.979 μs |  0.8401 μs |  0.7858 μs |   58712 B |
| ComputeHash · Whirlpool · Whirlpool (BouncyCastle) | 8KB          |   455.873 μs |  1.5255 μs |  1.2738 μs |     232 B |
|                                                    |              |              |            |            |           |
| ComputeHash · Whirlpool · Whirlpool (Managed)      | 128KB        | 1,561.260 μs |  4.0001 μs |  3.3403 μs |     176 B |
| ComputeHash · Whirlpool · Whirlpool (HashifyNET)   | 128KB        | 2,326.038 μs |  8.0126 μs |  7.4950 μs |  857445 B |
| ComputeHash · Whirlpool · Whirlpool (BouncyCastle) | 128KB        | 7,172.782 μs | 26.3883 μs | 22.0354 μs |     232 B |
