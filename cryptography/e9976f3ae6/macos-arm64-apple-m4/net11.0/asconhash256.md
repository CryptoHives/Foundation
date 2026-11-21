| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     636.8 ns |     2.17 ns |     2.03 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     924.5 ns |     2.47 ns |     2.31 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     666.5 ns |     2.58 ns |     2.41 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     967.0 ns |     5.22 ns |     4.88 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,246.1 ns |    24.95 ns |    23.34 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   6,060.9 ns |    23.64 ns |    22.11 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,241.1 ns |    23.91 ns |    22.37 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   6,053.8 ns |    18.53 ns |    17.34 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  32,757.3 ns |   127.04 ns |   118.83 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  47,112.7 ns |   208.58 ns |   195.11 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 517,641.8 ns | 3,594.96 ns | 3,362.73 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 748,248.9 ns | 2,228.97 ns | 1,975.92 ns |         - |