| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     621.6 ns |     2.38 ns |     2.23 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     911.7 ns |     3.38 ns |     3.16 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     652.6 ns |     1.70 ns |     1.33 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     956.8 ns |     5.90 ns |     5.23 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,109.1 ns |    20.79 ns |    19.45 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   5,999.0 ns |    24.66 ns |    23.07 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,165.6 ns |    22.78 ns |    21.31 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   5,991.4 ns |    33.47 ns |    31.31 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  32,529.9 ns |   176.82 ns |   156.75 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  46,569.5 ns |   221.13 ns |   206.84 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 510,844.3 ns | 2,658.13 ns | 2,486.41 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 741,076.8 ns | 2,917.02 ns | 2,728.58 ns |         - |