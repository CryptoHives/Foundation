| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |       895.7 ns |     0.67 ns |     0.62 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2,031.6 ns |     4.88 ns |     4.56 ns |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     4,460.8 ns |     1.94 ns |     1.72 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |       893.7 ns |     1.82 ns |     1.70 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2,031.4 ns |     5.39 ns |     5.04 ns |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     4,457.0 ns |     8.61 ns |     8.06 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     4,967.9 ns |    12.29 ns |    11.50 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    10,522.3 ns |     9.95 ns |     9.31 ns |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    27,505.4 ns |    34.02 ns |    31.82 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     4,969.4 ns |    14.16 ns |    13.25 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10,527.6 ns |     8.46 ns |     7.92 ns |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    27,510.6 ns |    21.59 ns |    20.19 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    37,613.5 ns |    23.22 ns |    21.72 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    77,767.4 ns |   171.26 ns |   151.81 ns |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   212,008.4 ns |   133.78 ns |   125.14 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   596,980.2 ns |   396.22 ns |   370.63 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,248,892.2 ns | 2,966.65 ns | 2,775.00 ns |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,362,476.2 ns | 3,470.97 ns | 3,246.75 ns |      56 B |