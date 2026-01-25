| Description          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------- |------------- |-------------:|------------:|------------:|----------:|
| Kmac128_DotNet       | 128B         |     972.7 ns |     7.75 ns |     6.87 ns |      32 B |
| Kmac128_CryptoHives  | 128B         |   1,264.2 ns |    11.39 ns |    10.65 ns |    2088 B |
| Kmac128_BouncyCastle | 128B         |   1,314.4 ns |     4.21 ns |     3.94 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_DotNet       | 137B         |     975.1 ns |     7.73 ns |     7.23 ns |      32 B |
| Kmac128_CryptoHives  | 137B         |   1,264.2 ns |     7.29 ns |     6.46 ns |    2088 B |
| Kmac128_BouncyCastle | 137B         |   1,311.5 ns |     6.16 ns |     5.46 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_DotNet       | 1KB          |   2,387.8 ns |    19.25 ns |    18.01 ns |      32 B |
| Kmac128_CryptoHives  | 1KB          |   2,535.1 ns |    15.67 ns |    14.66 ns |    2088 B |
| Kmac128_BouncyCastle | 1KB          |   3,149.7 ns |     8.84 ns |     7.38 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_DotNet       | 1025B        |   2,393.7 ns |    12.92 ns |    12.09 ns |      32 B |
| Kmac128_CryptoHives  | 1025B        |   2,536.7 ns |    12.53 ns |    11.72 ns |    2088 B |
| Kmac128_BouncyCastle | 1025B        |   3,158.8 ns |    17.38 ns |    16.25 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 8KB          |  11,026.4 ns |    47.61 ns |    44.54 ns |    2088 B |
| Kmac128_DotNet       | 8KB          |  12,317.9 ns |   104.59 ns |    92.72 ns |      32 B |
| Kmac128_BouncyCastle | 8KB          |  16,030.0 ns |    82.91 ns |    73.50 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 128KB        | 159,229.7 ns | 1,377.20 ns | 1,288.24 ns |    2088 B |
| Kmac128_DotNet       | 128KB        | 185,139.0 ns | 1,102.82 ns | 1,031.58 ns |      32 B |
| Kmac128_BouncyCastle | 128KB        | 239,536.1 ns |   975.00 ns |   912.02 ns |     160 B |