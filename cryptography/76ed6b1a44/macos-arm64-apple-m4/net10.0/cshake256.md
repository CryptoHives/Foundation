| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128B         |     160.9 ns |     0.98 ns |     0.76 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     171.4 ns |     0.89 ns |     0.75 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     179.7 ns |     0.49 ns |     0.45 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 137B         |     305.4 ns |     0.26 ns |     0.20 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     327.3 ns |     0.38 ns |     0.34 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |     336.5 ns |     1.03 ns |     0.91 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1KB          |   1,228.1 ns |     4.29 ns |     4.01 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   1,275.7 ns |    12.12 ns |    10.74 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   1,302.6 ns |    21.02 ns |    19.66 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1025B        |   1,222.1 ns |     1.40 ns |     1.09 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   1,267.5 ns |     3.94 ns |     3.50 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   1,290.0 ns |     3.78 ns |     3.16 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 8KB          |   9,314.5 ns |    16.66 ns |    15.59 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |   9,502.6 ns |    39.18 ns |    34.73 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |   9,725.9 ns |    15.54 ns |    12.98 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 146,894.1 ns |   272.24 ns |   227.34 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 151,896.5 ns | 2,910.90 ns | 2,722.86 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 153,825.0 ns |   356.39 ns |   297.60 ns |         - |