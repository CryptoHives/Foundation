| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128B         |     160.6 ns |   0.41 ns |   0.38 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     172.7 ns |   0.36 ns |   0.34 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     182.1 ns |   0.45 ns |   0.40 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 137B         |     305.8 ns |   0.34 ns |   0.32 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |     326.4 ns |   0.55 ns |   0.48 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     327.9 ns |   0.42 ns |   0.39 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1KB          |   1,208.1 ns |   1.11 ns |   0.98 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   1,288.1 ns |   4.20 ns |   3.93 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   1,298.8 ns |   4.83 ns |   4.28 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1025B        |   1,210.2 ns |   1.18 ns |   1.10 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   1,268.1 ns |   4.13 ns |   3.66 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   1,287.8 ns |   3.35 ns |   2.80 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 8KB          |   9,169.2 ns |  16.44 ns |  14.57 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |   9,567.6 ns | 110.75 ns | 103.59 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |   9,755.3 ns |  13.14 ns |  11.65 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 145,579.8 ns | 303.95 ns | 284.31 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 150,320.9 ns | 287.88 ns | 224.76 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 154,178.7 ns | 376.58 ns | 352.26 ns |         - |