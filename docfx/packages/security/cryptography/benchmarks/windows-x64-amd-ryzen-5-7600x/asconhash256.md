| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     564.7 ns |     3.13 ns |     2.61 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     764.3 ns |     6.30 ns |     5.90 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     596.8 ns |     2.21 ns |     2.07 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     802.6 ns |     3.35 ns |     3.13 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   3,658.2 ns |    16.48 ns |    13.76 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   4,951.2 ns |    16.97 ns |    15.04 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   3,662.0 ns |    11.72 ns |    10.39 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   4,969.6 ns |    23.35 ns |    20.70 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  28,395.7 ns |    88.53 ns |    82.81 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  38,488.8 ns |   161.04 ns |   134.47 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 470,123.1 ns | 1,795.60 ns | 1,401.89 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 615,321.1 ns | 4,345.47 ns | 3,852.15 ns |         - |