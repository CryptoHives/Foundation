| Description          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------- |------------- |-------------:|------------:|------------:|----------:|
| Kmac256_CryptoHives  | 128B         |     717.7 ns |     3.26 ns |     3.05 ns |     176 B |
| Kmac256_DotNet       | 128B         |   1,005.9 ns |     4.30 ns |     3.59 ns |      32 B |
| Kmac256_BouncyCastle | 128B         |   1,346.0 ns |     6.79 ns |     6.02 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 137B         |     970.6 ns |     5.36 ns |     4.48 ns |     176 B |
| Kmac256_DotNet       | 137B         |   1,257.0 ns |     8.71 ns |     7.72 ns |      32 B |
| Kmac256_BouncyCastle | 137B         |   1,640.7 ns |     6.47 ns |     5.41 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 1KB          |   2,168.2 ns |    36.98 ns |    48.08 ns |     176 B |
| Kmac256_DotNet       | 1KB          |   2,712.5 ns |    27.34 ns |    25.57 ns |      32 B |
| Kmac256_BouncyCastle | 1KB          |   3,573.0 ns |    22.01 ns |    18.38 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 1025B        |   2,157.2 ns |     8.17 ns |     6.82 ns |     176 B |
| Kmac256_DotNet       | 1025B        |   2,691.7 ns |     6.26 ns |     5.86 ns |      32 B |
| Kmac256_BouncyCastle | 1025B        |   3,518.4 ns |     7.34 ns |     5.73 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 8KB          |  12,894.7 ns |    46.75 ns |    43.73 ns |     176 B |
| Kmac256_DotNet       | 8KB          |  15,526.9 ns |    68.42 ns |    60.65 ns |      32 B |
| Kmac256_BouncyCastle | 8KB          |  19,966.9 ns |    57.80 ns |    51.24 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 128KB        | 196,367.8 ns |   715.34 ns |   669.13 ns |     176 B |
| Kmac256_DotNet       | 128KB        | 233,885.1 ns | 1,140.20 ns | 1,010.75 ns |      32 B |
| Kmac256_BouncyCastle | 128KB        | 302,226.0 ns | 1,006.63 ns |   892.35 ns |     160 B |