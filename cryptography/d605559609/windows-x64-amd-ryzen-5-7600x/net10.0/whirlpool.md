| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     1.396 μs | 0.0069 μs | 0.0057 μs |   5,043 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2.172 μs | 0.0427 μs | 0.0379 μs |        NA |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     5.213 μs | 0.0135 μs | 0.0106 μs |  10,711 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     1.402 μs | 0.0146 μs | 0.0122 μs |   5,049 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2.165 μs | 0.0372 μs | 0.0330 μs |        NA |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     5.253 μs | 0.0630 μs | 0.0619 μs |  10,711 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     7.810 μs | 0.0233 μs | 0.0182 μs |   5,043 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    10.813 μs | 0.0546 μs | 0.0426 μs |        NA |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    32.297 μs | 0.2290 μs | 0.2142 μs |  10,706 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     7.763 μs | 0.0249 μs | 0.0221 μs |   5,054 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10.849 μs | 0.0489 μs | 0.0409 μs |        NA |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    32.376 μs | 0.1599 μs | 0.1335 μs |  10,706 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    58.400 μs | 0.1074 μs | 0.0839 μs |   5,043 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    79.889 μs | 0.6071 μs | 0.5069 μs |        NA |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   247.777 μs | 0.8095 μs | 0.7176 μs |  10,709 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   939.463 μs | 4.8039 μs | 4.0115 μs |   5,053 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,308.059 μs | 6.3871 μs | 5.6620 μs |        NA |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,922.361 μs | 8.4709 μs | 9.4154 μs |  10,707 B |      56 B |