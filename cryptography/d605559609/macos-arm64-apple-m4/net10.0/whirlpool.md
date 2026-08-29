| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |       891.2 ns |     1.67 ns |     1.48 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2,043.5 ns |     2.25 ns |     1.88 ns |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     4,433.4 ns |     3.35 ns |     2.80 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |       889.2 ns |     0.88 ns |     0.78 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2,035.5 ns |     2.19 ns |     1.83 ns |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     4,433.1 ns |     1.21 ns |     0.94 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     4,946.7 ns |     4.34 ns |     3.85 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    10,465.2 ns |     5.59 ns |     4.36 ns |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    27,331.7 ns |     7.11 ns |     5.55 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     4,947.9 ns |     4.80 ns |     4.00 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10,472.1 ns |     7.04 ns |     6.24 ns |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    27,332.5 ns |     6.27 ns |     4.89 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    37,383.4 ns |    16.81 ns |    14.04 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    77,206.6 ns |    34.98 ns |    29.21 ns |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   210,936.6 ns |    95.82 ns |    74.81 ns |      56 B |
|                                                 |              |                |             |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   610,100.5 ns |   149.33 ns |   116.59 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,248,389.3 ns |   800.34 ns |   624.85 ns |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,345,362.3 ns | 4,115.05 ns | 3,436.26 ns |      56 B |