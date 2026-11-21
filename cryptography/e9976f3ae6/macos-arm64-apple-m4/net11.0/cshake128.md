| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128B         |     162.7 ns |   0.44 ns |   0.41 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     174.8 ns |   0.41 ns |   0.38 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     175.6 ns |   1.07 ns |   1.01 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 137B         |     163.5 ns |   0.44 ns |   0.41 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     175.0 ns |   0.41 ns |   0.38 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     176.2 ns |   1.47 ns |   1.37 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   1,065.9 ns |   2.95 ns |   2.76 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   1,099.5 ns |   9.07 ns |   8.48 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   1,156.8 ns |   2.55 ns |   2.26 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1025B        |   1,068.5 ns |   4.24 ns |   3.96 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   1,097.8 ns |   4.77 ns |   4.46 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   1,160.4 ns |   2.62 ns |   2.32 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   7,366.9 ns |  19.64 ns |  18.38 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |   7,559.4 ns |  21.58 ns |  18.02 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |   8,010.5 ns |  42.54 ns |  39.79 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 118,541.9 ns | 537.35 ns | 502.64 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 123,450.7 ns | 620.65 ns | 580.56 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 126,899.7 ns | 263.35 ns | 233.45 ns |         - |