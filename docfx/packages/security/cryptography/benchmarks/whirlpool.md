| Description                               | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Whirlpool · Managed      | 128B         |     1.331 μs |  0.0048 μs |  0.0042 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 128B         |     2.014 μs |  0.0202 μs |  0.0189 μs |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle | 128B         |     5.046 μs |  0.0346 μs |  0.0323 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 137B         |     1.345 μs |  0.0079 μs |  0.0074 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 137B         |     2.011 μs |  0.0202 μs |  0.0189 μs |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle | 137B         |     5.028 μs |  0.0311 μs |  0.0291 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 1KB          |     7.552 μs |  0.0378 μs |  0.0354 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 1KB          |    10.253 μs |  0.0684 μs |  0.0640 μs |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle | 1KB          |    31.014 μs |  0.2705 μs |  0.2530 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 1025B        |     7.443 μs |  0.0324 μs |  0.0303 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 1025B        |    10.232 μs |  0.0769 μs |  0.0681 μs |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle | 1025B        |    31.039 μs |  0.2415 μs |  0.2259 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 8KB          |    56.265 μs |  0.2283 μs |  0.2136 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 8KB          |    75.972 μs |  0.5555 μs |  0.4924 μs |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle | 8KB          |   238.152 μs |  1.4179 μs |  1.3263 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 128KB        |   907.956 μs |  5.2726 μs |  4.9320 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 128KB        | 1,249.177 μs |  5.7231 μs |  4.4682 μs |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle | 128KB        | 3,795.729 μs | 17.2025 μs | 15.2495 μs |      56 B |