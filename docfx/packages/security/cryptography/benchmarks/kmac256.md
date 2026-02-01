| Description          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------- |------------- |-------------:|------------:|------------:|----------:|
| Kmac256_DotNet       | 128B         |     972.8 ns |     5.09 ns |     4.76 ns |      32 B |
| Kmac256_BouncyCastle | 128B         |   1,316.5 ns |     6.85 ns |     6.07 ns |     160 B |
| Kmac256_CryptoHives  | 128B         |   1,349.7 ns |     7.23 ns |     6.04 ns |    1992 B |
|                      |              |              |             |             |           |
| Kmac256_DotNet       | 137B         |   1,212.3 ns |     8.18 ns |     7.25 ns |      32 B |
| Kmac256_CryptoHives  | 137B         |   1,483.8 ns |    11.92 ns |     9.96 ns |    1992 B |
| Kmac256_BouncyCastle | 137B         |   1,596.2 ns |     8.44 ns |     7.48 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_DotNet       | 1KB          |   2,613.4 ns |    14.73 ns |    13.78 ns |      32 B |
| Kmac256_CryptoHives  | 1KB          |   2,652.2 ns |    18.84 ns |    17.62 ns |    1992 B |
| Kmac256_BouncyCastle | 1KB          |   3,431.7 ns |    14.28 ns |    12.66 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_DotNet       | 1025B        |   2,609.8 ns |    14.59 ns |    12.93 ns |      32 B |
| Kmac256_CryptoHives  | 1025B        |   2,654.2 ns |    18.49 ns |    17.30 ns |    1992 B |
| Kmac256_BouncyCastle | 1025B        |   3,432.9 ns |    27.84 ns |    24.68 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 8KB          |  13,172.2 ns |    71.77 ns |    67.13 ns |    1992 B |
| Kmac256_DotNet       | 8KB          |  15,048.1 ns |    80.57 ns |    75.36 ns |      32 B |
| Kmac256_BouncyCastle | 8KB          |  19,549.6 ns |    77.02 ns |    72.04 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 128KB        | 190,798.3 ns | 1,204.26 ns | 1,126.46 ns |    1992 B |
| Kmac256_DotNet       | 128KB        | 226,867.5 ns |   865.58 ns |   767.31 ns |      32 B |
| Kmac256_BouncyCastle | 128KB        | 293,415.3 ns | 1,142.44 ns | 1,068.64 ns |     160 B |