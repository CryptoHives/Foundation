| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128B         |     160.3 ns |   0.26 ns |   0.25 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     170.0 ns |   0.40 ns |   0.37 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     174.7 ns |   1.28 ns |   1.20 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 137B         |     309.2 ns |   0.77 ns |   0.72 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |     316.5 ns |   2.00 ns |   1.67 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     327.8 ns |   0.40 ns |   0.38 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1KB          |   1,212.9 ns |   5.10 ns |   4.77 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   1,257.3 ns |   3.13 ns |   2.78 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   1,288.8 ns |   3.94 ns |   3.68 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1025B        |   1,224.2 ns |   4.91 ns |   4.59 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   1,269.8 ns |   7.04 ns |   6.58 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   1,290.5 ns |   2.43 ns |   2.16 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 8KB          |   9,206.9 ns |   8.11 ns |   7.58 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |   9,257.8 ns |  49.45 ns |  41.29 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |   9,741.8 ns |  34.63 ns |  32.39 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 146,752.3 ns | 521.15 ns | 487.48 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128KB        | 147,122.0 ns | 171.65 ns | 160.56 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 154,139.3 ns | 172.51 ns | 161.37 ns |         - |