| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     1.403 μs |  0.0065 μs |  0.0058 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2.224 μs |  0.0390 μs |  0.0346 μs |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     5.249 μs |  0.0393 μs |  0.0367 μs |      56 B |
|                                                 |              |              |            |            |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     1.672 μs |  0.0038 μs |  0.0035 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2.208 μs |  0.0266 μs |  0.0249 μs |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     5.192 μs |  0.0188 μs |  0.0166 μs |      56 B |
|                                                 |              |              |            |            |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     7.785 μs |  0.0242 μs |  0.0215 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    10.873 μs |  0.0753 μs |  0.0629 μs |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    32.031 μs |  0.1487 μs |  0.1391 μs |      56 B |
|                                                 |              |              |            |            |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     7.652 μs |  0.0226 μs |  0.0212 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10.830 μs |  0.0920 μs |  0.0861 μs |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    31.948 μs |  0.1868 μs |  0.1656 μs |      56 B |
|                                                 |              |              |            |            |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    59.530 μs |  0.2170 μs |  0.1923 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    79.513 μs |  0.4038 μs |  0.3372 μs |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   247.069 μs |  1.1389 μs |  1.0653 μs |      56 B |
|                                                 |              |              |            |            |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   937.726 μs |  4.1141 μs |  3.6470 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,305.569 μs |  4.4440 μs |  3.9395 μs |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,918.851 μs | 19.7292 μs | 17.4894 μs |      56 B |