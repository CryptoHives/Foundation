| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     654.7 ns |     2.34 ns |     2.19 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     909.9 ns |     0.27 ns |     0.25 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     682.6 ns |     2.65 ns |     2.48 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     949.3 ns |     0.14 ns |     0.13 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,348.6 ns |    19.48 ns |    18.22 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   5,970.7 ns |     3.96 ns |     3.09 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,345.6 ns |    25.07 ns |    23.45 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   6,015.3 ns |     2.41 ns |     2.25 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  33,914.3 ns |   160.27 ns |   149.92 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  46,821.7 ns |    18.47 ns |    16.38 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 532,547.7 ns | 3,634.23 ns | 3,399.46 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 745,755.8 ns |   320.98 ns |   300.24 ns |         - |