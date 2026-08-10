| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     584.0 ns |    11.23 ns |    14.61 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     761.9 ns |     2.43 ns |     2.03 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     601.7 ns |     3.57 ns |     3.34 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     805.2 ns |     7.03 ns |     6.23 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   3,667.6 ns |    13.05 ns |    11.57 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   5,174.2 ns |    77.77 ns |    68.94 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   3,674.7 ns |    21.74 ns |    20.33 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   4,936.1 ns |    17.59 ns |    13.74 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  28,470.4 ns |   160.34 ns |   142.14 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  38,261.2 ns |   179.13 ns |   167.56 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 452,295.0 ns | 1,546.53 ns | 1,370.96 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 611,390.1 ns | 3,643.14 ns | 3,042.18 ns |         - |