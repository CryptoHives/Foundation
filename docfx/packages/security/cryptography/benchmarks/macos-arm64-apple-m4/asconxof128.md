| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     620.5 ns |     1.66 ns |     1.55 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     895.1 ns |     6.11 ns |     5.10 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     654.0 ns |     1.93 ns |     1.80 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     945.2 ns |     1.87 ns |     1.66 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   4,133.3 ns |    17.42 ns |    15.44 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   5,892.3 ns |    29.19 ns |    24.37 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   4,140.8 ns |    17.14 ns |    15.20 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   5,963.5 ns |    47.18 ns |    46.34 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  32,461.6 ns |   160.42 ns |   142.20 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  46,017.5 ns |   128.03 ns |   119.76 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 514,819.5 ns | 2,785.03 ns | 2,605.12 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 731,904.6 ns | 3,069.82 ns | 2,871.51 ns |         - |