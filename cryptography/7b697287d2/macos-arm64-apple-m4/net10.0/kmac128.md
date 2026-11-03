| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     489.0 ns |   0.38 ns |   0.36 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   1,030.1 ns |   2.61 ns |   2.31 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     488.8 ns |   0.19 ns |   0.16 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   1,038.7 ns |   5.44 ns |   5.09 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,381.9 ns |   1.20 ns |   1.12 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   1,956.2 ns |  11.00 ns |  10.29 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,382.1 ns |   1.23 ns |   1.15 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   1,984.7 ns |  13.17 ns |  12.32 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |   7,653.8 ns |  29.96 ns |  28.02 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |   8,452.1 ns |  49.64 ns |  44.00 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 117,766.9 ns | 470.03 ns | 439.67 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 121,847.3 ns | 406.65 ns | 360.49 ns |     256 B |