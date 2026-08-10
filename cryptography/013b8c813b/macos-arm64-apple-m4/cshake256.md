| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128B         |     159.9 ns |   0.14 ns |   0.13 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     169.2 ns |   0.09 ns |   0.08 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     178.4 ns |   0.59 ns |   0.55 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 137B         |     303.6 ns |   0.14 ns |   0.13 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     325.3 ns |   0.25 ns |   0.21 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |     326.3 ns |   0.31 ns |   0.24 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1KB          |   1,201.7 ns |   1.89 ns |   1.76 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   1,265.4 ns |  10.17 ns |   9.51 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   1,282.1 ns |   1.29 ns |   1.08 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1025B        |   1,200.4 ns |   0.73 ns |   0.65 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   1,264.1 ns |   4.27 ns |   3.57 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   1,285.1 ns |   3.84 ns |   3.20 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 8KB          |   9,133.9 ns |   9.11 ns |   8.52 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |   9,550.7 ns |  64.23 ns |  56.94 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |   9,696.8 ns |  17.24 ns |  16.13 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 144,639.3 ns | 201.10 ns | 178.27 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 152,973.3 ns | 463.45 ns | 433.52 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 153,066.7 ns | 212.68 ns | 188.54 ns |         - |