| Description                                         | TestDataSize | Mean         | Error        | StdDev      | Allocated |
|---------------------------------------------------- |------------- |-------------:|-------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     664.3 ns |      7.72 ns |     7.22 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     918.5 ns |     10.64 ns |     9.95 ns |         - |
|                                                     |              |              |              |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     690.5 ns |      8.05 ns |     7.53 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     957.9 ns |      1.11 ns |     0.86 ns |         - |
|                                                     |              |              |              |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,409.1 ns |     13.85 ns |    10.81 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   6,067.9 ns |     79.65 ns |    74.51 ns |         - |
|                                                     |              |              |              |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,366.0 ns |     65.15 ns |    57.75 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   6,080.7 ns |     87.99 ns |    82.30 ns |         - |
|                                                     |              |              |              |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  33,939.6 ns |    102.22 ns |    79.81 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  47,307.5 ns |    630.14 ns |   589.44 ns |         - |
|                                                     |              |              |              |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 539,896.3 ns |  1,913.66 ns | 1,494.06 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 752,333.6 ns | 10,563.07 ns | 9,880.70 ns |         - |