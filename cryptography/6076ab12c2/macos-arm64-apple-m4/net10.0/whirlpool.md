| Description                                     | TestDataSize | Mean           | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |---------------:|----------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |       890.0 ns |   0.43 ns |   0.40 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2,032.6 ns |   3.50 ns |   3.10 ns |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     4,426.4 ns |   3.54 ns |   3.14 ns |      56 B |
|                                                 |              |                |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |       889.2 ns |   0.38 ns |   0.36 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2,067.2 ns |   1.50 ns |   1.33 ns |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     4,497.3 ns |   1.71 ns |   1.60 ns |      56 B |
|                                                 |              |                |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     5,024.3 ns |   0.79 ns |   0.70 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    10,667.9 ns |   8.63 ns |   7.65 ns |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    27,756.7 ns |   7.68 ns |   6.41 ns |      56 B |
|                                                 |              |                |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     5,023.4 ns |   2.39 ns |   2.12 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10,696.1 ns |  16.33 ns |  14.48 ns |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    27,756.1 ns |   6.76 ns |   5.99 ns |      56 B |
|                                                 |              |                |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    37,999.1 ns |  15.24 ns |  12.73 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    78,572.1 ns |  37.86 ns |  35.41 ns |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   215,982.1 ns |  42.67 ns |  39.92 ns |      56 B |
|                                                 |              |                |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   602,384.7 ns | 336.87 ns | 298.63 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,265,018.4 ns | 780.93 ns | 652.11 ns |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,395,582.0 ns | 764.85 ns | 678.02 ns |      56 B |