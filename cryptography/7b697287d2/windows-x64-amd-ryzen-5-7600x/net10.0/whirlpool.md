| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     1.524 μs |  0.0033 μs |  0.0031 μs |   3,242 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2.293 μs |  0.0085 μs |  0.0075 μs |  24,464 B |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     5.805 μs |  0.0115 μs |  0.0102 μs |   8,097 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     1.521 μs |  0.0031 μs |  0.0029 μs |   3,248 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2.296 μs |  0.0133 μs |  0.0125 μs |  24,476 B |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     5.814 μs |  0.0136 μs |  0.0127 μs |   8,105 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     8.534 μs |  0.0274 μs |  0.0256 μs |   3,242 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    11.748 μs |  0.0368 μs |  0.0344 μs |  24,399 B |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    35.855 μs |  0.0840 μs |  0.0786 μs |   8,119 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     8.553 μs |  0.0255 μs |  0.0226 μs |   3,253 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    11.753 μs |  0.0454 μs |  0.0402 μs |  24,661 B |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    35.695 μs |  0.0865 μs |  0.0809 μs |   8,119 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    65.756 μs |  0.1371 μs |  0.1282 μs |   3,242 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    87.326 μs |  0.2828 μs |  0.2646 μs |  24,854 B |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   276.077 μs |  0.5178 μs |  0.4590 μs |   8,097 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        | 1,025.641 μs |  3.4847 μs |  3.2596 μs |   3,252 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,439.372 μs |  4.4091 μs |  3.9085 μs |  24,744 B |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 4,371.637 μs | 15.3039 μs | 14.3153 μs |   8,119 B |      56 B |