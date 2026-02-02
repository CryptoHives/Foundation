| Description          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------- |------------- |-------------:|------------:|------------:|----------:|
| Kmac128_CryptoHives  | 128B         |     700.5 ns |     9.96 ns |     8.83 ns |     112 B |
| Kmac128_DotNet       | 128B         |     981.5 ns |     9.83 ns |     9.20 ns |      32 B |
| Kmac128_BouncyCastle | 128B         |   1,356.2 ns |    27.10 ns |    27.83 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 137B         |     693.4 ns |     4.47 ns |     4.18 ns |     112 B |
| Kmac128_DotNet       | 137B         |     995.7 ns |    15.32 ns |    14.33 ns |      32 B |
| Kmac128_BouncyCastle | 137B         |   1,327.6 ns |    13.29 ns |    11.78 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 1KB          |   1,938.0 ns |    16.85 ns |    15.76 ns |     112 B |
| Kmac128_DotNet       | 1KB          |   2,407.4 ns |    16.75 ns |    15.67 ns |      32 B |
| Kmac128_BouncyCastle | 1KB          |   3,184.1 ns |    35.09 ns |    32.82 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 1025B        |   1,940.1 ns |    16.02 ns |    14.20 ns |     112 B |
| Kmac128_DotNet       | 1025B        |   2,423.0 ns |    29.62 ns |    26.26 ns |      32 B |
| Kmac128_BouncyCastle | 1025B        |   3,172.4 ns |    17.44 ns |    15.46 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 8KB          |  10,278.2 ns |    79.72 ns |    66.57 ns |     112 B |
| Kmac128_DotNet       | 8KB          |  12,437.2 ns |    87.31 ns |    81.67 ns |      32 B |
| Kmac128_BouncyCastle | 8KB          |  16,262.1 ns |   249.89 ns |   233.75 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 128KB        | 155,910.8 ns |   819.48 ns |   684.30 ns |     112 B |
| Kmac128_DotNet       | 128KB        | 186,836.6 ns | 1,266.61 ns | 1,122.82 ns |      32 B |
| Kmac128_BouncyCastle | 128KB        | 240,238.3 ns | 1,664.59 ns | 1,557.06 ns |     160 B |