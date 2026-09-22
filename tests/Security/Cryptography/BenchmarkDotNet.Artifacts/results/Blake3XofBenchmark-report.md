```

BenchmarkDotNet v0.15.8, macOS Tahoe 26.6.2 (25G83) [Darwin 25.6.0]
Apple M4, 1 CPU, 10 logical and 10 physical cores
.NET SDK 10.0.400
  [Host]    : .NET 10.0.11 (10.0.11, 10.0.1126.37416), Arm64 RyuJIT armv8.0-a
  .NET 10.0 : .NET 10.0.11 (10.0.11, 10.0.1126.37416), Arm64 RyuJIT armv8.0-a

Method=AbsorbSqueeze  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |   1.656 μs | 0.0045 μs | 0.0042 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   1.926 μs | 0.0066 μs | 0.0061 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128B         |   1.942 μs | 0.0063 μs | 0.0059 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |   2.099 μs | 0.0074 μs | 0.0069 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |   2.124 μs | 0.0065 μs | 0.0061 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  12.477 μs | 0.0338 μs | 0.0316 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |   2.287 μs | 0.0079 μs | 0.0074 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 1KB          |   2.305 μs | 0.0086 μs | 0.0081 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |   2.678 μs | 0.0060 μs | 0.0056 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |   2.859 μs | 0.0099 μs | 0.0093 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |   2.872 μs | 0.0084 μs | 0.0078 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  17.804 μs | 0.0493 μs | 0.0461 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 8KB          |   5.528 μs | 0.0202 μs | 0.0179 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |   7.337 μs | 0.0258 μs | 0.0201 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |   8.678 μs | 0.0194 μs | 0.0182 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |   9.009 μs | 0.1107 μs | 0.0925 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |   9.042 μs | 0.0237 μs | 0.0210 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  57.548 μs | 0.1969 μs | 0.1644 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128KB        |  61.569 μs | 1.2209 μs | 1.5440 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |  94.325 μs | 1.6528 μs | 1.5460 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        | 111.345 μs | 0.1820 μs | 0.1614 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        | 112.020 μs | 1.8427 μs | 1.6335 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        | 112.502 μs | 0.3191 μs | 0.2985 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 732.723 μs | 2.2171 μs | 2.0739 μs |      56 B |
