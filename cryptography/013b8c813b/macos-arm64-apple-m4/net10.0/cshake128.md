| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128B         |     160.8 ns |   0.13 ns |   0.12 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     171.3 ns |   0.18 ns |   0.15 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     178.9 ns |   0.18 ns |   0.15 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 137B         |     159.8 ns |   0.19 ns |   0.18 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     170.8 ns |   0.12 ns |   0.10 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     180.1 ns |   0.29 ns |   0.24 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   1,050.5 ns |   0.73 ns |   0.64 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   1,114.2 ns |   1.12 ns |   0.87 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   1,127.6 ns |   1.91 ns |   1.70 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1025B        |   1,049.4 ns |   1.03 ns |   0.91 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   1,113.8 ns |   2.14 ns |   1.89 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   1,127.2 ns |   0.60 ns |   0.50 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   7,281.6 ns |   3.07 ns |   2.87 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |   7,683.2 ns |  50.45 ns |  44.72 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |   7,817.0 ns |  10.75 ns |   8.98 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 116,737.6 ns |  62.56 ns |  55.46 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 121,959.6 ns | 403.13 ns | 336.63 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 124,507.2 ns | 264.15 ns | 247.09 ns |         - |