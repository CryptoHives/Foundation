| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     654.2 ns |     0.73 ns |     0.68 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     912.8 ns |     0.84 ns |     0.79 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     691.9 ns |     2.07 ns |     1.94 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     959.0 ns |     0.57 ns |     0.53 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,320.5 ns |    17.54 ns |    15.55 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   6,046.3 ns |     4.62 ns |     4.10 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,389.0 ns |    20.44 ns |    19.12 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   6,045.7 ns |     3.53 ns |     3.30 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  34,210.4 ns |   164.04 ns |   153.44 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  47,000.3 ns |    39.93 ns |    37.35 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 537,543.6 ns | 2,678.30 ns | 2,505.28 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 748,931.4 ns | 1,672.50 ns | 1,564.45 ns |         - |