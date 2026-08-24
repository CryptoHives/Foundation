| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     658.9 ns |   0.12 ns |   0.11 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     921.8 ns |   1.47 ns |   1.23 ns |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     685.5 ns |   0.18 ns |   0.16 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     967.0 ns |   0.66 ns |   0.61 ns |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   4,399.6 ns |  22.39 ns |  19.85 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   6,033.2 ns |   6.45 ns |   5.71 ns |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   4,233.4 ns |  21.81 ns |  20.40 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   6,035.8 ns |   3.48 ns |   3.25 ns |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  33,933.4 ns | 155.17 ns | 145.15 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  47,008.9 ns |  28.41 ns |  25.18 ns |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 539,732.5 ns | 547.92 ns | 485.72 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 749,408.3 ns | 517.61 ns | 484.17 ns |         - |