| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Median       | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|-------------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     1.133 μs |  0.0181 μs |  0.0169 μs |     1.134 μs |         - |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     5.614 μs |  0.1116 μs |  0.1096 μs |     5.587 μs |      56 B |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     9.610 μs |  0.0219 μs |  0.0205 μs |     9.600 μs |    6336 B |
|                                                 |              |              |            |            |              |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     4.193 μs |  0.0031 μs |  0.0029 μs |     4.193 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     9.565 μs |  0.0126 μs |  0.0112 μs |     9.563 μs |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |    20.834 μs |  0.0200 μs |  0.0167 μs |    20.836 μs |      56 B |
|                                                 |              |              |            |            |              |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |    23.307 μs |  0.0217 μs |  0.0193 μs |    23.299 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    49.302 μs |  0.1792 μs |  0.1588 μs |    49.312 μs |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |   129.007 μs |  0.0765 μs |  0.0678 μs |   129.004 μs |      56 B |
|                                                 |              |              |            |            |              |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |    23.375 μs |  0.0408 μs |  0.0362 μs |    23.359 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    49.649 μs |  0.2104 μs |  0.1968 μs |    49.563 μs |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |   128.865 μs |  0.1104 μs |  0.0979 μs |   128.810 μs |      56 B |
|                                                 |              |              |            |            |              |           |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    78.555 μs |  0.0453 μs |  0.0378 μs |    78.552 μs |   58624 B |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |   176.477 μs |  0.2910 μs |  0.2430 μs |   176.402 μs |         - |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   239.981 μs | 16.8001 μs | 47.6590 μs |   213.974 μs |      56 B |
|                                                 |              |              |            |            |              |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   593.085 μs |  0.3528 μs |  0.3300 μs |   593.025 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,247.871 μs |  1.6894 μs |  1.4977 μs | 1,247.650 μs |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,341.684 μs |  0.4976 μs |  0.4411 μs | 3,341.676 μs |      56 B |