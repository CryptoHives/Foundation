| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     630.6 ns |     1.93 ns |     1.81 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     915.7 ns |     2.64 ns |     2.47 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     663.0 ns |     2.29 ns |     2.14 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     961.1 ns |     5.62 ns |     5.25 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   4,174.0 ns |    14.95 ns |    13.25 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   6,010.8 ns |    11.05 ns |     9.79 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   4,163.3 ns |    17.84 ns |    16.69 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   6,018.5 ns |    10.39 ns |     9.21 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  32,601.7 ns |   153.85 ns |   143.91 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  46,829.1 ns |   145.53 ns |   136.13 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 517,924.3 ns | 2,564.32 ns | 2,398.67 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 745,957.9 ns | 2,643.63 ns | 2,472.85 ns |         - |