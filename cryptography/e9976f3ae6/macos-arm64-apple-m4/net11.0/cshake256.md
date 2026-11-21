| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128B         |     162.1 ns |   0.37 ns |   0.35 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     174.8 ns |   0.56 ns |   0.52 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     175.8 ns |   0.80 ns |   0.74 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 137B         |     307.8 ns |   0.60 ns |   0.56 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |     322.2 ns |   1.89 ns |   1.58 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     333.4 ns |   0.97 ns |   0.91 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1KB          |   1,213.9 ns |   7.15 ns |   6.69 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   1,245.8 ns |   7.00 ns |   6.21 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   1,315.2 ns |   4.58 ns |   4.28 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1025B        |   1,224.7 ns |   4.25 ns |   3.97 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   1,252.0 ns |   3.64 ns |   3.23 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   1,316.0 ns |   3.12 ns |   2.92 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |   9,320.9 ns |  41.56 ns |  32.45 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 8KB          |   9,325.1 ns |  28.60 ns |  26.75 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |   9,880.0 ns |  22.50 ns |  21.05 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 147,658.3 ns | 726.32 ns | 606.51 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 147,907.4 ns | 495.27 ns | 463.28 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 156,101.6 ns | 253.73 ns | 224.92 ns |         - |