| Description                                     | TestDataSize | Mean          | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |--------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |      2.726 μs |  0.0023 μs |  0.0022 μs |  12,481 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |      4.858 μs |  0.0085 μs |  0.0079 μs |  36,422 B |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     11.445 μs |  0.0708 μs |  0.0662 μs |  19,436 B |      56 B |
|                                                 |              |               |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |      2.724 μs |  0.0015 μs |  0.0013 μs |  12,477 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |      4.841 μs |  0.0114 μs |  0.0101 μs |  38,244 B |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     11.401 μs |  0.0514 μs |  0.0481 μs |  19,427 B |      56 B |
|                                                 |              |               |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     15.195 μs |  0.0040 μs |  0.0034 μs |  12,291 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |     24.425 μs |  0.0336 μs |  0.0314 μs |  29,850 B |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |     70.840 μs |  0.6986 μs |  0.6535 μs |  19,250 B |      56 B |
|                                                 |              |               |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     15.207 μs |  0.0039 μs |  0.0032 μs |   5,957 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |     24.844 μs |  0.0376 μs |  0.0334 μs |  31,095 B |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |     70.107 μs |  0.5119 μs |  0.4788 μs |  19,241 B |      56 B |
|                                                 |              |               |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    115.325 μs |  0.0159 μs |  0.0133 μs |  12,291 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    182.898 μs |  0.2286 μs |  0.2027 μs |  41,977 B |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |    705.224 μs |  2.6333 μs |  2.4632 μs |  19,267 B |      56 B |
|                                                 |              |               |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |  1,826.674 μs |  0.3726 μs |  0.3112 μs |   5,966 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        |  3,018.126 μs |  3.1685 μs |  2.9638 μs |  35,251 B |  857395 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 11,149.931 μs | 54.0454 μs | 45.1303 μs |  19,257 B |      56 B |