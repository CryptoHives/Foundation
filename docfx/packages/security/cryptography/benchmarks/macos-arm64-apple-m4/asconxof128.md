| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     657.0 ns |     2.30 ns |     2.15 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     909.0 ns |     2.86 ns |     2.68 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     683.5 ns |     2.68 ns |     2.51 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     958.6 ns |     1.02 ns |     0.96 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   4,382.4 ns |    19.57 ns |    18.30 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   6,034.6 ns |     3.72 ns |     3.48 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   4,321.7 ns |    21.04 ns |    19.68 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   6,013.2 ns |     2.83 ns |     2.65 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  33,750.9 ns |   166.07 ns |   155.34 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  46,824.5 ns |    35.98 ns |    33.66 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 538,023.9 ns | 2,205.74 ns | 2,063.25 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 745,560.2 ns |   876.83 ns |   820.19 ns |         - |