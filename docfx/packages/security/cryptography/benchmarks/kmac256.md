| Description          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------- |------------- |-------------:|------------:|------------:|----------:|
| Kmac256_CryptoHives  | 128B         |     697.6 ns |     3.64 ns |     3.40 ns |     176 B |
| Kmac256_DotNet       | 128B         |     964.1 ns |     5.07 ns |     4.24 ns |      32 B |
| Kmac256_BouncyCastle | 128B         |   1,300.0 ns |    10.87 ns |    10.17 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 137B         |     939.5 ns |     3.75 ns |     3.33 ns |     176 B |
| Kmac256_DotNet       | 137B         |   1,215.1 ns |     8.74 ns |     8.17 ns |      32 B |
| Kmac256_BouncyCastle | 137B         |   1,597.4 ns |     5.80 ns |     5.42 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 1KB          |   2,093.0 ns |    14.83 ns |    13.87 ns |     176 B |
| Kmac256_DotNet       | 1KB          |   2,610.7 ns |    14.61 ns |    13.67 ns |      32 B |
| Kmac256_BouncyCastle | 1KB          |   3,440.8 ns |    19.99 ns |    17.72 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 1025B        |   2,103.6 ns |    14.53 ns |    13.59 ns |     176 B |
| Kmac256_DotNet       | 1025B        |   2,611.4 ns |    14.24 ns |    12.62 ns |      32 B |
| Kmac256_BouncyCastle | 1025B        |   3,420.1 ns |    14.94 ns |    13.98 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 8KB          |  12,842.3 ns |    43.08 ns |    38.19 ns |     176 B |
| Kmac256_DotNet       | 8KB          |  15,023.8 ns |    59.50 ns |    52.74 ns |      32 B |
| Kmac256_BouncyCastle | 8KB          |  19,451.5 ns |   115.69 ns |   108.22 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 128KB        | 190,622.4 ns |   960.04 ns |   851.05 ns |     176 B |
| Kmac256_DotNet       | 128KB        | 226,444.0 ns | 1,436.04 ns | 1,343.28 ns |      32 B |
| Kmac256_BouncyCastle | 128KB        | 291,536.7 ns | 1,685.97 ns | 1,577.06 ns |     160 B |