| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     553.6 ns |   0.69 ns |   0.61 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   1,052.0 ns |   1.54 ns |   1.36 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     548.1 ns |   0.87 ns |   0.81 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   1,056.5 ns |   4.20 ns |   3.28 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,597.0 ns |   3.23 ns |   2.70 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   2,039.7 ns |   6.97 ns |   6.18 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,594.1 ns |   2.50 ns |   2.34 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   2,008.9 ns |  13.35 ns |  11.83 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |   8,187.6 ns |   6.22 ns |   4.85 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |   8,620.3 ns |  68.86 ns |  61.05 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 123,300.1 ns | 570.03 ns | 476.00 ns |     256 B |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 124,885.7 ns | 138.11 ns | 129.19 ns |         - |