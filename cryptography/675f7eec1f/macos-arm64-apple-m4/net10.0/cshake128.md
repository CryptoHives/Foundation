| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128B         |     161.1 ns |   0.18 ns |   0.17 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     172.7 ns |   0.12 ns |   0.11 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     179.5 ns |   0.78 ns |   0.69 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 137B         |     163.1 ns |   0.14 ns |   0.13 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     172.0 ns |   0.31 ns |   0.29 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     180.8 ns |   0.94 ns |   0.83 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   1,060.9 ns |   3.13 ns |   2.44 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   1,120.9 ns |   1.10 ns |   0.92 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   1,136.1 ns |   2.39 ns |   2.24 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1025B        |   1,058.3 ns |   1.10 ns |   1.03 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   1,127.5 ns |   3.24 ns |   2.87 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   1,137.9 ns |   3.27 ns |   2.90 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   7,380.3 ns |   4.97 ns |   4.65 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |   7,737.2 ns |   2.92 ns |   2.28 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |   7,862.4 ns |  24.65 ns |  20.59 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 117,379.6 ns | 335.41 ns | 313.74 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 122,669.3 ns | 493.58 ns | 437.55 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 125,353.8 ns | 169.02 ns | 158.10 ns |         - |