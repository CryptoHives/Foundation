| Description          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------- |------------- |-------------:|------------:|------------:|----------:|
| Kmac128_CryptoHives  | 128B         |     690.7 ns |     2.60 ns |     2.17 ns |     112 B |
| Kmac128_DotNet       | 128B         |     974.3 ns |    10.36 ns |     9.69 ns |      32 B |
| Kmac128_BouncyCastle | 128B         |   1,316.3 ns |    11.72 ns |    10.97 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 137B         |     689.2 ns |     5.48 ns |     4.86 ns |     112 B |
| Kmac128_DotNet       | 137B         |     978.5 ns |     6.78 ns |     6.34 ns |      32 B |
| Kmac128_BouncyCastle | 137B         |   1,322.9 ns |     5.04 ns |     4.47 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 1KB          |   1,919.2 ns |     8.92 ns |     7.90 ns |     112 B |
| Kmac128_DotNet       | 1KB          |   2,376.5 ns |    12.93 ns |    10.80 ns |      32 B |
| Kmac128_BouncyCastle | 1KB          |   3,144.4 ns |    12.79 ns |    11.96 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 1025B        |   1,928.0 ns |     8.76 ns |     7.77 ns |     112 B |
| Kmac128_DotNet       | 1025B        |   2,391.6 ns |    19.26 ns |    17.07 ns |      32 B |
| Kmac128_BouncyCastle | 1025B        |   3,154.7 ns |    16.41 ns |    14.55 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 8KB          |  10,258.8 ns |    48.27 ns |    42.79 ns |     112 B |
| Kmac128_DotNet       | 8KB          |  12,310.5 ns |    51.65 ns |    45.78 ns |      32 B |
| Kmac128_BouncyCastle | 8KB          |  16,016.4 ns |   100.15 ns |    93.68 ns |     160 B |
|                      |              |              |             |             |           |
| Kmac128_CryptoHives  | 128KB        | 155,909.9 ns |   977.02 ns |   866.11 ns |     112 B |
| Kmac128_DotNet       | 128KB        | 185,267.8 ns | 1,349.52 ns | 1,262.34 ns |      32 B |
| Kmac128_BouncyCastle | 128KB        | 240,571.9 ns | 1,041.07 ns |   973.82 ns |     160 B |