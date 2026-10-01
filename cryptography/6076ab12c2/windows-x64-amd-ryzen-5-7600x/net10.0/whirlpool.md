| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     1.565 μs | 0.0034 μs | 0.0031 μs |   3,293 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2.372 μs | 0.0330 μs | 0.0293 μs |  24,468 B |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     5.834 μs | 0.0208 μs | 0.0185 μs |   8,105 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     1.547 μs | 0.0049 μs | 0.0046 μs |   3,299 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2.373 μs | 0.0339 μs | 0.0317 μs |  24,457 B |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     5.847 μs | 0.0158 μs | 0.0140 μs |   8,103 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     8.681 μs | 0.0318 μs | 0.0281 μs |   3,293 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    12.188 μs | 0.1269 μs | 0.1187 μs |  24,380 B |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    35.875 μs | 0.1307 μs | 0.1092 μs |   8,097 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     8.687 μs | 0.0359 μs | 0.0336 μs |   3,304 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    11.728 μs | 0.0443 μs | 0.0415 μs |  24,757 B |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    35.637 μs | 0.0407 μs | 0.0381 μs |   8,097 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    66.054 μs | 0.0815 μs | 0.0762 μs |   3,298 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    87.001 μs | 0.1507 μs | 0.1336 μs |  24,761 B |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   274.312 μs | 0.3358 μs | 0.2977 μs |   8,105 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        | 1,037.439 μs | 1.4720 μs | 1.3049 μs |   3,303 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,446.504 μs | 3.7747 μs | 3.3462 μs |  24,732 B |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 4,358.507 μs | 7.6999 μs | 7.2025 μs |   8,097 B |      56 B |