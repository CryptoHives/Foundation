| Description          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------- |------------- |-------------:|------------:|------------:|----------:|
| Kmac256_DotNet       | 128B         |     973.3 ns |     6.25 ns |     5.22 ns |      32 B |
| Kmac256_CryptoHives  | 128B         |   1,260.0 ns |     7.44 ns |     6.60 ns |    1992 B |
| Kmac256_BouncyCastle | 128B         |   1,303.9 ns |     5.34 ns |     5.00 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_DotNet       | 137B         |   1,219.0 ns |     9.17 ns |     8.57 ns |      32 B |
| Kmac256_CryptoHives  | 137B         |   1,521.1 ns |    18.16 ns |    15.16 ns |    1992 B |
| Kmac256_BouncyCastle | 137B         |   1,598.8 ns |     7.05 ns |     6.59 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_DotNet       | 1KB          |   2,628.1 ns |    23.92 ns |    22.38 ns |      32 B |
| Kmac256_CryptoHives  | 1KB          |   2,717.6 ns |    25.82 ns |    24.16 ns |    1992 B |
| Kmac256_BouncyCastle | 1KB          |   3,444.8 ns |    18.16 ns |    16.98 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_DotNet       | 1025B        |   2,620.0 ns |    27.13 ns |    25.37 ns |      32 B |
| Kmac256_CryptoHives  | 1025B        |   2,723.3 ns |    32.27 ns |    30.19 ns |    1992 B |
| Kmac256_BouncyCastle | 1025B        |   3,435.8 ns |    17.92 ns |    16.77 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 8KB          |  13,468.2 ns |    77.85 ns |    72.82 ns |    1992 B |
| Kmac256_DotNet       | 8KB          |  15,169.4 ns |   160.46 ns |   150.09 ns |      32 B |
| Kmac256_BouncyCastle | 8KB          |  19,690.9 ns |   218.40 ns |   204.29 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 128KB        | 195,605.5 ns | 1,042.03 ns |   923.74 ns |    1992 B |
| Kmac256_DotNet       | 128KB        | 228,676.0 ns | 1,683.81 ns | 1,492.66 ns |      32 B |
| Kmac256_BouncyCastle | 128KB        | 296,529.9 ns | 3,885.15 ns | 3,244.27 ns |     160 B |