| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     636.4 ns |     2.48 ns |     2.32 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     921.6 ns |     2.55 ns |     2.39 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     668.2 ns |     2.20 ns |     1.95 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     968.0 ns |     4.05 ns |     3.79 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   4,225.5 ns |    23.28 ns |    21.78 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   6,046.5 ns |    16.59 ns |    14.70 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   4,215.7 ns |    23.29 ns |    21.78 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   6,044.9 ns |    21.13 ns |    19.77 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  32,840.3 ns |   117.82 ns |   110.21 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  46,874.9 ns |   173.88 ns |   162.65 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 521,029.1 ns | 2,586.62 ns | 2,419.53 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 746,938.5 ns | 1,801.00 ns | 1,596.54 ns |         - |