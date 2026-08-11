| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     1.426 μs |  0.0053 μs |  0.0047 μs |   5,043 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2.177 μs |  0.0264 μs |  0.0234 μs |        NA |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     5.259 μs |  0.0232 μs |  0.0217 μs |  10,709 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     1.405 μs |  0.0038 μs |  0.0034 μs |   5,049 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2.179 μs |  0.0237 μs |  0.0222 μs |        NA |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     5.299 μs |  0.0334 μs |  0.0313 μs |  10,706 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     7.796 μs |  0.0214 μs |  0.0167 μs |   5,043 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    11.009 μs |  0.1119 μs |  0.1047 μs |        NA |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    32.524 μs |  0.1562 μs |  0.1461 μs |  10,733 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     8.006 μs |  0.0182 μs |  0.0152 μs |   5,054 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10.941 μs |  0.0915 μs |  0.0811 μs |        NA |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    33.004 μs |  0.1342 μs |  0.1255 μs |  10,711 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    60.759 μs |  0.2112 μs |  0.1764 μs |   5,050 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    80.120 μs |  0.3958 μs |  0.3305 μs |        NA |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   249.300 μs |  0.8097 μs |  0.6761 μs |  10,711 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   952.941 μs |  6.0384 μs |  5.0423 μs |   5,053 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,317.595 μs |  7.0467 μs |  5.8843 μs |        NA |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,963.812 μs | 13.4541 μs | 12.5850 μs |  10,711 B |      56 B |