| Description                                     | TestDataSize | Mean           | Error        | StdDev       | Median         | Allocated |
|------------------------------------------------ |------------- |---------------:|-------------:|-------------:|---------------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |       888.9 ns |      0.24 ns |      0.18 ns |       888.9 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2,026.0 ns |      4.09 ns |      3.19 ns |     2,025.7 ns |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     4,422.7 ns |      1.10 ns |      1.03 ns |     4,422.7 ns |      56 B |
|                                                 |              |                |              |              |                |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     1,037.5 ns |     27.99 ns |     82.09 ns |     1,051.9 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2,325.8 ns |     46.23 ns |    107.14 ns |     2,292.4 ns |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     5,094.1 ns |     97.07 ns |     95.34 ns |     5,131.0 ns |      56 B |
|                                                 |              |                |              |              |                |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     6,139.3 ns |    122.69 ns |    274.42 ns |     6,152.2 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    12,644.7 ns |    243.09 ns |    289.38 ns |    12,686.5 ns |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    32,763.8 ns |    334.45 ns |    296.48 ns |    32,783.7 ns |      56 B |
|                                                 |              |                |              |              |                |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     6,294.9 ns |    125.28 ns |    247.30 ns |     6,322.8 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    12,596.6 ns |    250.40 ns |    451.52 ns |    12,841.8 ns |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    33,358.4 ns |    656.70 ns |    781.76 ns |    33,403.8 ns |      56 B |
|                                                 |              |                |              |              |                |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    49,324.3 ns |    787.31 ns |    736.45 ns |    49,305.8 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    95,635.7 ns |  1,894.59 ns |  2,893.25 ns |    94,716.2 ns |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   253,323.2 ns |  2,027.35 ns |  1,896.38 ns |   253,832.3 ns |      56 B |
|                                                 |              |                |              |              |                |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   784,346.0 ns | 12,363.80 ns | 10,324.33 ns |   786,799.2 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,253,976.4 ns | 19,043.29 ns | 15,902.01 ns | 1,246,891.2 ns |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 4,387,056.8 ns | 47,538.81 ns | 37,115.18 ns | 4,372,241.2 ns |      56 B |