| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     1.379 μs |  0.0061 μs |  0.0051 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2.033 μs |  0.0197 μs |  0.0174 μs |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     5.086 μs |  0.0412 μs |  0.0344 μs |      56 B |
|                                                 |              |              |            |            |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     1.348 μs |  0.0053 μs |  0.0044 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2.026 μs |  0.0182 μs |  0.0161 μs |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     5.090 μs |  0.0509 μs |  0.0476 μs |      56 B |
|                                                 |              |              |            |            |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     7.629 μs |  0.0608 μs |  0.0569 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    10.342 μs |  0.1014 μs |  0.0949 μs |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    31.173 μs |  0.1905 μs |  0.1782 μs |      56 B |
|                                                 |              |              |            |            |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     7.522 μs |  0.0406 μs |  0.0380 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10.320 μs |  0.0812 μs |  0.0760 μs |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    31.374 μs |  0.2503 μs |  0.2341 μs |      56 B |
|                                                 |              |              |            |            |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    56.757 μs |  0.2586 μs |  0.2292 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    76.504 μs |  0.6803 μs |  0.6030 μs |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   240.925 μs |  1.8231 μs |  1.7053 μs |      56 B |
|                                                 |              |              |            |            |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   909.667 μs |  2.7528 μs |  2.4403 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,265.003 μs |  9.5233 μs |  8.4421 μs |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,807.944 μs | 20.7161 μs | 19.3779 μs |      56 B |