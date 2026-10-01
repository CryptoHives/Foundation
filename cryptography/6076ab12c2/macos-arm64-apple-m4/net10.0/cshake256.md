| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128B         |     161.7 ns |   0.16 ns |   0.14 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     172.7 ns |   0.23 ns |   0.21 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     179.0 ns |   0.84 ns |   0.79 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 137B         |     312.5 ns |   0.17 ns |   0.15 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |     324.9 ns |   1.95 ns |   1.83 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     337.2 ns |   0.29 ns |   0.25 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1KB          |   1,227.2 ns |   0.60 ns |   0.53 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   1,289.6 ns |   6.51 ns |   5.77 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   1,312.4 ns |   2.26 ns |   2.00 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1025B        |   1,222.7 ns |   0.99 ns |   0.92 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   1,256.3 ns |   8.40 ns |   7.02 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   1,311.2 ns |   1.21 ns |   1.07 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 8KB          |   9,293.1 ns |   7.26 ns |   5.67 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |   9,391.1 ns |  57.22 ns |  50.73 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |   9,903.5 ns |  14.76 ns |  13.80 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 147,071.0 ns | 187.51 ns | 175.39 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 148,299.4 ns | 346.86 ns | 289.64 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 156,866.9 ns | 202.49 ns | 179.50 ns |         - |