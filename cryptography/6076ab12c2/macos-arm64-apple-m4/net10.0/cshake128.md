| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128B         |     162.5 ns |   0.10 ns |   0.09 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     172.4 ns |   0.32 ns |   0.28 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     177.1 ns |   1.89 ns |   1.77 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 137B         |     161.2 ns |   0.18 ns |   0.16 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     170.5 ns |   0.26 ns |   0.23 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     178.0 ns |   1.50 ns |   1.40 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   1,050.6 ns |   1.05 ns |   0.93 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   1,091.4 ns |   3.46 ns |   2.89 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   1,134.6 ns |   2.39 ns |   2.24 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1025B        |   1,054.8 ns |   1.13 ns |   1.06 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   1,118.5 ns |   9.04 ns |   8.01 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   1,141.9 ns |   3.23 ns |   3.02 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   7,296.6 ns |   4.98 ns |   4.66 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |   7,479.5 ns |  17.98 ns |  14.04 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |   7,870.7 ns |  12.60 ns |   9.84 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 116,496.9 ns | 106.06 ns |  94.02 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 120,045.9 ns | 937.81 ns | 877.23 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 125,332.7 ns | 276.31 ns | 244.94 ns |         - |