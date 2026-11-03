| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     617.3 ns |     2.21 ns |     2.07 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     904.9 ns |     3.54 ns |     3.31 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     647.6 ns |     1.40 ns |     1.24 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     954.2 ns |     5.27 ns |     4.40 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   4,111.9 ns |    18.81 ns |    17.59 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   5,951.9 ns |    29.44 ns |    27.54 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   4,108.7 ns |    23.09 ns |    21.59 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   5,938.4 ns |    21.23 ns |    19.86 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  32,131.0 ns |   168.92 ns |   158.00 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  46,223.2 ns |   225.62 ns |   211.05 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 510,437.6 ns | 2,398.70 ns | 2,243.75 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 737,092.3 ns | 2,503.07 ns | 2,341.37 ns |         - |