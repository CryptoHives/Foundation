| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     640.0 ns |     2.51 ns |     2.23 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     926.4 ns |     2.32 ns |     2.17 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     662.7 ns |     3.09 ns |     2.89 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     970.6 ns |     3.90 ns |     3.46 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,241.7 ns |    21.17 ns |    19.80 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   6,083.4 ns |    16.23 ns |    14.39 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,174.3 ns |    21.63 ns |    20.23 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   6,081.6 ns |    14.68 ns |    13.73 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  32,581.6 ns |   140.67 ns |   124.70 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  47,217.4 ns |   150.91 ns |   141.16 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 518,467.1 ns | 2,533.64 ns | 2,369.97 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 752,265.2 ns | 2,471.75 ns | 2,191.15 ns |         - |