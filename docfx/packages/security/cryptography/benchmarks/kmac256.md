| Description          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------- |------------- |-------------:|------------:|------------:|----------:|
| Kmac256_DotNet       | 128B         |     983.9 ns |     8.56 ns |     8.01 ns |      32 B |
| Kmac256_CryptoHives  | 128B         |   1,263.7 ns |     8.95 ns |     8.37 ns |    1992 B |
| Kmac256_BouncyCastle | 128B         |   1,298.1 ns |     9.75 ns |     9.12 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_DotNet       | 137B         |   1,226.5 ns |     5.78 ns |     5.41 ns |      32 B |
| Kmac256_CryptoHives  | 137B         |   1,508.3 ns |     7.29 ns |     6.82 ns |    1992 B |
| Kmac256_BouncyCastle | 137B         |   1,592.9 ns |     6.82 ns |     6.04 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_DotNet       | 1KB          |   2,599.3 ns |    14.32 ns |    11.96 ns |      32 B |
| Kmac256_CryptoHives  | 1KB          |   2,695.3 ns |    18.76 ns |    17.55 ns |    1992 B |
| Kmac256_BouncyCastle | 1KB          |   3,430.1 ns |    22.36 ns |    19.82 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_DotNet       | 1025B        |   2,613.3 ns |    16.28 ns |    15.23 ns |      32 B |
| Kmac256_CryptoHives  | 1025B        |   2,709.4 ns |     8.42 ns |     7.03 ns |    1992 B |
| Kmac256_BouncyCastle | 1025B        |   3,425.2 ns |    13.10 ns |    12.26 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 8KB          |  13,410.3 ns |    79.26 ns |    74.14 ns |    1992 B |
| Kmac256_DotNet       | 8KB          |  15,130.7 ns |   129.38 ns |   114.70 ns |      32 B |
| Kmac256_BouncyCastle | 8KB          |  19,511.7 ns |    85.75 ns |    80.21 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 128KB        | 194,877.8 ns |   946.55 ns |   885.40 ns |    1992 B |
| Kmac256_DotNet       | 128KB        | 226,677.6 ns |   586.41 ns |   519.84 ns |      32 B |
| Kmac256_BouncyCastle | 128KB        | 293,625.0 ns | 1,716.52 ns | 1,605.63 ns |     160 B |