| Description          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------- |------------- |-------------:|------------:|------------:|----------:|
| Kmac128_DotNet       | 128B         |     984.6 ns |    10.26 ns |     9.09 ns |      32 B |
| Kmac128_CryptoHives  | 128B         |   1,273.3 ns |    14.90 ns |    13.94 ns |    2088 B |
| Kmac128_BouncyCastle | 128B         |   1,341.3 ns |    10.72 ns |     9.50 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_DotNet       | 137B         |     988.8 ns |    12.45 ns |    11.65 ns |      32 B |
| Kmac128_CryptoHives  | 137B         |   1,265.0 ns |    11.02 ns |    10.30 ns |    2088 B |
| Kmac128_BouncyCastle | 137B         |   1,320.1 ns |     6.51 ns |     5.77 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_DotNet       | 1KB          |   2,408.6 ns |    19.23 ns |    17.99 ns |      32 B |
| Kmac128_CryptoHives  | 1KB          |   2,551.3 ns |    19.94 ns |    18.65 ns |    2088 B |
| Kmac128_BouncyCastle | 1KB          |   3,172.5 ns |    18.25 ns |    17.07 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_DotNet       | 1025B        |   2,415.3 ns |    26.71 ns |    22.30 ns |      32 B |
| Kmac128_CryptoHives  | 1025B        |   2,553.7 ns |    33.93 ns |    31.74 ns |    2088 B |
| Kmac128_BouncyCastle | 1025B        |   3,163.8 ns |    22.58 ns |    21.12 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 8KB          |  11,095.6 ns |    79.84 ns |    74.68 ns |    2088 B |
| Kmac128_DotNet       | 8KB          |  12,440.0 ns |   103.78 ns |    97.08 ns |      32 B |
| Kmac128_BouncyCastle | 8KB          |  16,148.6 ns |   134.13 ns |   112.00 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 128KB        | 160,191.2 ns |   851.63 ns |   796.62 ns |    2088 B |
| Kmac128_DotNet       | 128KB        | 186,974.5 ns | 1,497.15 ns | 1,400.43 ns |      32 B |
| Kmac128_BouncyCastle | 128KB        | 241,338.0 ns | 1,660.12 ns | 1,471.65 ns |     160 B |