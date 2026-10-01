| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     628.2 ns |     2.22 ns |     2.07 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     920.9 ns |     1.83 ns |     1.71 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     659.1 ns |     2.82 ns |     2.64 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     964.9 ns |     3.43 ns |     3.04 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   4,177.3 ns |    12.32 ns |    11.53 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   6,032.3 ns |    35.05 ns |    31.07 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   4,172.2 ns |    17.05 ns |    15.94 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   6,022.4 ns |    24.07 ns |    22.51 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  32,563.6 ns |   166.34 ns |   147.46 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  46,826.3 ns |   182.09 ns |   170.33 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 518,799.7 ns | 2,233.47 ns | 2,089.19 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 746,318.9 ns | 2,423.55 ns | 2,148.41 ns |         - |