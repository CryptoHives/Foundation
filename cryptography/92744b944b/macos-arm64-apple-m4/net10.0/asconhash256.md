| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     635.8 ns |     4.52 ns |     3.78 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     905.8 ns |     5.06 ns |     4.22 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     661.2 ns |     2.57 ns |     2.40 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     949.8 ns |     5.87 ns |     4.90 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,203.6 ns |    13.47 ns |    11.25 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   5,944.4 ns |    34.78 ns |    29.04 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,205.1 ns |    16.44 ns |    15.38 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   5,960.7 ns |    10.23 ns |     9.57 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  32,710.5 ns |   119.97 ns |   106.35 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  46,325.1 ns |   153.17 ns |   135.78 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 513,382.5 ns | 1,573.39 ns | 1,394.77 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 736,800.5 ns | 2,810.19 ns | 2,491.16 ns |         - |