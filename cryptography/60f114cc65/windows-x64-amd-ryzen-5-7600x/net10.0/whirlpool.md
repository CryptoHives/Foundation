| Description                               | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Whirlpool · Managed      | 128B         |     1.356 μs |  0.0114 μs |  0.0101 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 128B         |     2.068 μs |  0.0409 μs |  0.0574 μs |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle | 128B         |     5.114 μs |  0.0425 μs |  0.0397 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 137B         |     1.359 μs |  0.0125 μs |  0.0117 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 137B         |     2.058 μs |  0.0384 μs |  0.0341 μs |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle | 137B         |     5.095 μs |  0.0371 μs |  0.0347 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 1KB          |     7.640 μs |  0.0649 μs |  0.0607 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 1KB          |    10.389 μs |  0.1797 μs |  0.1501 μs |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle | 1KB          |    31.449 μs |  0.3294 μs |  0.2920 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 1025B        |     7.598 μs |  0.1327 μs |  0.1109 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 1025B        |    10.513 μs |  0.1207 μs |  0.1129 μs |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle | 1025B        |    31.318 μs |  0.2335 μs |  0.2070 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 8KB          |    57.164 μs |  0.2885 μs |  0.2699 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 8KB          |    77.183 μs |  0.9550 μs |  0.7975 μs |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle | 8KB          |   243.569 μs |  1.8137 μs |  1.6078 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 128KB        |   905.461 μs |  6.8868 μs |  6.1050 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 128KB        | 1,279.580 μs | 21.7291 μs | 19.2623 μs |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle | 128KB        | 3,858.954 μs | 26.8356 μs | 22.4090 μs |      56 B |