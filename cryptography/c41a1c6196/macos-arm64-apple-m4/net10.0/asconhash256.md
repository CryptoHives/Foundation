| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     645.6 ns |     3.08 ns |     2.88 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     928.9 ns |     2.97 ns |     2.78 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     676.7 ns |     3.30 ns |     3.08 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     976.0 ns |     3.94 ns |     3.69 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,246.0 ns |    28.51 ns |    26.67 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   6,107.5 ns |    14.04 ns |    12.45 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,237.3 ns |    24.29 ns |    22.72 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   6,107.3 ns |    19.07 ns |    17.84 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  33,276.8 ns |   164.89 ns |   137.69 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  47,417.4 ns |   194.80 ns |   182.21 ns |         - |
|                                                     |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 524,323.9 ns | 2,284.78 ns | 2,137.19 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 755,422.1 ns | 2,918.39 ns | 2,729.86 ns |         - |