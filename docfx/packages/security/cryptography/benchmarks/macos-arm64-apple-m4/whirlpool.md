| Description                                     | TestDataSize | Mean           | Error       | StdDev    | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |       890.0 ns |     0.48 ns |   0.43 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2,023.5 ns |     1.58 ns |   1.48 ns |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     4,430.8 ns |     2.07 ns |   1.83 ns |      56 B |
|                                                 |              |                |             |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |       888.5 ns |     0.63 ns |   0.59 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2,025.6 ns |     1.89 ns |   1.68 ns |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     4,418.0 ns |     1.07 ns |   0.90 ns |      56 B |
|                                                 |              |                |             |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     4,939.2 ns |     1.21 ns |   1.07 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    10,479.3 ns |     6.42 ns |   6.00 ns |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    27,301.4 ns |    10.18 ns |   9.03 ns |      56 B |
|                                                 |              |                |             |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     4,943.9 ns |     1.17 ns |   1.04 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10,497.9 ns |     3.08 ns |   2.88 ns |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    27,350.5 ns |     4.40 ns |   3.90 ns |      56 B |
|                                                 |              |                |             |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    38,359.4 ns |    10.54 ns |   8.80 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    77,244.6 ns |    27.29 ns |  24.20 ns |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   210,483.4 ns |    49.58 ns |  46.37 ns |      56 B |
|                                                 |              |                |             |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   592,780.3 ns |   313.32 ns | 261.64 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,243,068.3 ns |   901.02 ns | 842.82 ns |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,339,698.4 ns | 1,238.46 ns | 966.91 ns |      56 B |