| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     658.5 ns |     2.02 ns |     1.58 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     915.3 ns |    10.79 ns |    10.09 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     689.7 ns |     7.95 ns |     7.44 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     954.1 ns |     2.38 ns |     1.86 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   4,398.3 ns |    16.72 ns |    13.06 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   6,039.3 ns |    77.70 ns |    72.68 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   4,375.4 ns |    69.85 ns |    65.33 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   6,052.5 ns |    78.27 ns |    73.21 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  34,253.4 ns |   136.56 ns |   106.62 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  47,212.6 ns |   637.32 ns |   596.15 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 539,219.0 ns | 2,084.20 ns | 1,627.21 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 747,864.6 ns | 9,930.25 ns | 8,802.91 ns |         - |