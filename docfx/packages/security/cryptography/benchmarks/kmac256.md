| Description          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------- |------------- |-------------:|------------:|------------:|----------:|
| Kmac256_CryptoHives  | 128B         |     702.8 ns |     8.63 ns |     8.07 ns |     176 B |
| Kmac256_DotNet       | 128B         |     978.2 ns |    13.19 ns |    12.34 ns |      32 B |
| Kmac256_BouncyCastle | 128B         |   1,306.1 ns |    15.12 ns |    14.15 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 137B         |     943.6 ns |     5.27 ns |     4.12 ns |     176 B |
| Kmac256_DotNet       | 137B         |   1,218.8 ns |     6.49 ns |     5.76 ns |      32 B |
| Kmac256_BouncyCastle | 137B         |   1,629.9 ns |    31.68 ns |    33.89 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 1KB          |   2,102.9 ns |    12.08 ns |    10.71 ns |     176 B |
| Kmac256_DotNet       | 1KB          |   2,615.5 ns |    19.81 ns |    18.53 ns |      32 B |
| Kmac256_BouncyCastle | 1KB          |   3,461.5 ns |    52.12 ns |    46.20 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 1025B        |   2,100.6 ns |    10.70 ns |     8.94 ns |     176 B |
| Kmac256_DotNet       | 1025B        |   2,631.1 ns |    22.22 ns |    20.78 ns |      32 B |
| Kmac256_BouncyCastle | 1025B        |   3,438.0 ns |    21.03 ns |    18.64 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 8KB          |  12,579.1 ns |    51.26 ns |    45.44 ns |     176 B |
| Kmac256_DotNet       | 8KB          |  15,119.6 ns |   127.73 ns |   119.48 ns |      32 B |
| Kmac256_BouncyCastle | 8KB          |  19,514.5 ns |   109.20 ns |    96.81 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac256_CryptoHives  | 128KB        | 191,798.2 ns | 1,694.12 ns | 1,501.79 ns |     176 B |
| Kmac256_DotNet       | 128KB        | 227,899.1 ns |   884.37 ns |   783.97 ns |      32 B |
| Kmac256_BouncyCastle | 128KB        | 294,184.9 ns | 2,122.19 ns | 1,985.10 ns |     160 B |