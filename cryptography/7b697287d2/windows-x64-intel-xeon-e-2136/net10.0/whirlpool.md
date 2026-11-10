| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     2.732 μs |  0.0012 μs |  0.0010 μs |   3,278 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     4.545 μs |  0.0108 μs |  0.0101 μs |  25,577 B |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |    12.743 μs |  0.0560 μs |  0.0496 μs |   8,163 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     2.731 μs |  0.0027 μs |  0.0023 μs |   3,288 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     4.572 μs |  0.0142 μs |  0.0126 μs |  24,475 B |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |    12.814 μs |  0.0540 μs |  0.0479 μs |   8,163 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |    15.241 μs |  0.0068 μs |  0.0060 μs |   3,278 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    22.815 μs |  0.0369 μs |  0.0345 μs |  24,361 B |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    80.412 μs |  0.2523 μs |  0.2360 μs |   8,163 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |    15.310 μs |  0.0103 μs |  0.0097 μs |   3,291 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    22.951 μs |  0.0320 μs |  0.0284 μs |  24,761 B |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    80.458 μs |  0.1105 μs |  0.0979 μs |   8,163 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |   115.409 μs |  0.0610 μs |  0.0541 μs |   3,289 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |   167.471 μs |  0.1722 μs |  0.1611 μs |  25,004 B |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   622.291 μs |  1.6011 μs |  1.4193 μs |   8,163 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        | 1,838.789 μs |  0.7260 μs |  0.6791 μs |   3,288 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 2,766.807 μs |  3.7223 μs |  3.2997 μs |  24,878 B |  857370 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 8,695.172 μs | 25.9056 μs | 21.6324 μs |   8,158 B |      56 B |