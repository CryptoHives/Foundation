| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     658.6 ns |     0.52 ns |     0.43 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     925.8 ns |     1.27 ns |     0.99 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     686.2 ns |     2.30 ns |     1.92 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     976.4 ns |     7.71 ns |     6.44 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,414.0 ns |     5.60 ns |     4.96 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   6,093.0 ns |    16.03 ns |    13.39 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,409.1 ns |     4.62 ns |     3.85 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   6,104.6 ns |    12.89 ns |    11.43 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  34,010.2 ns |    78.96 ns |    69.99 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  47,375.0 ns |    74.39 ns |    62.11 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 541,129.4 ns |   965.18 ns |   805.97 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 755,687.0 ns | 1,620.21 ns | 1,436.28 ns |         - |