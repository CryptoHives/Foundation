| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     561.8 ns |     1.54 ns |     1.37 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     762.5 ns |     1.94 ns |     1.62 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     594.5 ns |     1.26 ns |     1.05 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     799.3 ns |     2.48 ns |     2.20 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   3,647.3 ns |     9.87 ns |     9.23 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   4,955.0 ns |    18.84 ns |    14.71 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   3,647.2 ns |     7.27 ns |     6.45 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   4,942.7 ns |     9.00 ns |     8.42 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  28,262.6 ns |    28.41 ns |    25.19 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  38,419.0 ns |    83.80 ns |    74.29 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 451,848.0 ns | 1,492.13 ns | 1,395.74 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 612,689.4 ns | 2,077.04 ns | 1,841.24 ns |         - |