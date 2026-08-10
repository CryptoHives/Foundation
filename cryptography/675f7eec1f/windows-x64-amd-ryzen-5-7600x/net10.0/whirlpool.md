| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     1.390 μs |  0.0184 μs |  0.0163 μs |   5,043 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2.451 μs |  0.0465 μs |  0.0710 μs |        NA |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     5.402 μs |  0.1056 μs |  0.1373 μs |  10,714 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     1.440 μs |  0.0241 μs |  0.0214 μs |   5,049 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2.415 μs |  0.0482 μs |  0.0995 μs |        NA |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     5.399 μs |  0.1023 μs |  0.0957 μs |  10,728 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     7.823 μs |  0.1308 μs |  0.1224 μs |   5,043 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    11.611 μs |  0.2195 μs |  0.1946 μs |        NA |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    33.203 μs |  0.6492 μs |  0.7728 μs |  10,706 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     7.948 μs |  0.1377 μs |  0.1150 μs |   5,054 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    11.172 μs |  0.1478 μs |  0.1382 μs |        NA |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    32.470 μs |  0.4741 μs |  0.4203 μs |  10,711 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    59.126 μs |  0.5526 μs |  0.4614 μs |   5,050 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    81.912 μs |  1.4015 μs |  1.3110 μs |        NA |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   251.052 μs |  3.1044 μs |  2.9039 μs |  10,711 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   948.971 μs | 14.3872 μs | 13.4578 μs |   5,053 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,350.298 μs | 25.6083 μs | 25.1508 μs |        NA |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 4,070.726 μs | 58.7677 μs | 54.9713 μs |  10,706 B |      56 B |