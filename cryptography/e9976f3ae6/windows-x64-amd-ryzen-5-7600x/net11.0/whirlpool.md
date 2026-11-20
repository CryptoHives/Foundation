| Description                                     | TestDataSize | Mean         | Error      | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|----------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     1.533 μs |  0.0054 μs | 0.0048 μs |  12,649 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2.395 μs |  0.0193 μs | 0.0162 μs |  29,185 B |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     5.742 μs |  0.0120 μs | 0.0106 μs |  12,825 B |      56 B |
|                                                 |              |              |            |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     1.534 μs |  0.0066 μs | 0.0058 μs |  12,240 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2.405 μs |  0.0082 μs | 0.0069 μs |  29,811 B |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     5.729 μs |  0.0121 μs | 0.0101 μs |  12,820 B |      56 B |
|                                                 |              |              |            |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     8.729 μs |  0.0277 μs | 0.0231 μs |   5,909 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    12.148 μs |  0.0327 μs | 0.0290 μs |  35,504 B |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    35.446 μs |  0.0751 μs | 0.0586 μs |  19,178 B |      56 B |
|                                                 |              |              |            |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     8.721 μs |  0.0255 μs | 0.0239 μs |  12,245 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    12.189 μs |  0.0340 μs | 0.0318 μs |  34,552 B |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    35.413 μs |  0.0822 μs | 0.0729 μs |  12,831 B |      56 B |
|                                                 |              |              |            |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    64.929 μs |  0.1702 μs | 0.1509 μs |  12,244 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    90.175 μs |  0.1891 μs | 0.1676 μs |  30,816 B |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   272.361 μs |  0.5711 μs | 0.5063 μs |  12,826 B |      56 B |
|                                                 |              |              |            |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        | 1,029.130 μs |  2.3389 μs | 2.0734 μs |   5,919 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,484.340 μs |  3.5375 μs | 3.3089 μs |  36,483 B |  857397 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 4,329.169 μs | 11.0054 μs | 9.1900 μs |  12,826 B |      56 B |