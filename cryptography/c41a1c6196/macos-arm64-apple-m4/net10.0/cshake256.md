| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128B         |     163.5 ns |   0.45 ns |   0.40 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     172.2 ns |   0.47 ns |   0.44 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     177.7 ns |   0.88 ns |   0.83 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 137B         |     314.2 ns |   1.01 ns |   0.94 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |     333.3 ns |   1.09 ns |   1.02 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     335.1 ns |   0.78 ns |   0.73 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1KB          |   1,219.6 ns |   3.48 ns |   3.26 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   1,289.6 ns |   8.02 ns |   7.50 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   1,306.5 ns |   4.41 ns |   4.13 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1025B        |   1,231.6 ns |   3.69 ns |   3.46 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   1,252.6 ns |   3.90 ns |   3.65 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   1,307.8 ns |   3.69 ns |   3.45 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 8KB          |   9,318.0 ns | 164.55 ns | 176.07 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |   9,387.3 ns |  46.16 ns |  43.18 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |   9,867.6 ns |  11.71 ns |  10.38 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 148,039.5 ns | 344.27 ns | 322.03 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 148,307.9 ns | 361.25 ns | 337.91 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 156,128.7 ns | 320.93 ns | 284.49 ns |         - |