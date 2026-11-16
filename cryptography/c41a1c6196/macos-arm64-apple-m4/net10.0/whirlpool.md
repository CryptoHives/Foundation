| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |       891.8 ns |     2.36 ns |     2.21 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2,076.9 ns |     5.61 ns |     5.24 ns |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     4,477.8 ns |    10.48 ns |     9.80 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |       890.9 ns |     2.09 ns |     1.96 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2,083.2 ns |     6.15 ns |     5.45 ns |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     4,466.7 ns |     8.55 ns |     7.58 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     5,059.0 ns |    98.01 ns |    86.88 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    10,655.5 ns |    50.38 ns |    47.12 ns |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    27,838.2 ns |   165.26 ns |   154.59 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     4,978.1 ns |    40.00 ns |    35.46 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10,719.0 ns |    77.97 ns |    72.93 ns |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    27,744.8 ns |   110.71 ns |   103.56 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    37,663.3 ns |   215.79 ns |   191.29 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    78,974.7 ns |   288.54 ns |   255.79 ns |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   213,451.3 ns |   280.09 ns |   261.99 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   596,565.1 ns |   994.48 ns |   930.24 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,261,992.1 ns | 5,419.74 ns | 5,069.63 ns |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,386,771.7 ns | 8,363.46 ns | 7,823.19 ns |      56 B |