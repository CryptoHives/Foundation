| Description                                     | TestDataSize | Mean         | Error      | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|------------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     1.363 μs |  0.0051 μs |   0.0045 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2.073 μs |  0.0400 μs |   0.0428 μs |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     5.083 μs |  0.0369 μs |   0.0345 μs |      56 B |
|                                                 |              |              |            |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     1.351 μs |  0.0070 μs |   0.0062 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2.036 μs |  0.0272 μs |   0.0213 μs |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     5.072 μs |  0.0323 μs |   0.0286 μs |      56 B |
|                                                 |              |              |            |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     7.711 μs |  0.1541 μs |   0.1441 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    10.358 μs |  0.1190 μs |   0.0993 μs |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    31.534 μs |  0.2556 μs |   0.1996 μs |      56 B |
|                                                 |              |              |            |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     7.546 μs |  0.0538 μs |   0.0477 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10.442 μs |  0.1020 μs |   0.0954 μs |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    31.855 μs |  0.6147 μs |   0.5449 μs |      56 B |
|                                                 |              |              |            |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    57.666 μs |  0.3466 μs |   0.2894 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    76.735 μs |  0.6326 μs |   0.5917 μs |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   240.761 μs |  2.8153 μs |   2.3509 μs |      56 B |
|                                                 |              |              |            |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   925.019 μs | 11.5015 μs |   9.6043 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,281.524 μs | 24.5294 μs |  27.2644 μs |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,901.330 μs | 71.6113 μs | 104.9670 μs |      56 B |