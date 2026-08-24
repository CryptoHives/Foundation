| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128B         |     756.4 ns |     0.89 ns |     0.74 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     809.7 ns |     3.77 ns |     3.53 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     814.5 ns |     4.36 ns |     3.64 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     170.6 ns |     2.95 ns |     6.36 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 137B         |     754.0 ns |     1.08 ns |     0.90 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     809.0 ns |     3.14 ns |     2.94 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   1,068.7 ns |     0.92 ns |     0.86 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   1,080.2 ns |     5.64 ns |     4.40 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   1,137.3 ns |     2.11 ns |     1.87 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1025B        |   1,048.3 ns |     0.93 ns |     0.78 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   1,125.1 ns |     6.75 ns |     6.32 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   1,136.9 ns |     3.38 ns |     3.16 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   8,242.4 ns |   163.04 ns |   426.65 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |   8,249.5 ns |    94.84 ns |    79.20 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |   8,629.7 ns |   110.86 ns |    98.27 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 136,291.0 ns | 2,716.58 ns | 4,463.42 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 140,277.5 ns | 2,638.03 ns | 2,467.61 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 148,087.5 ns | 2,929.52 ns | 3,373.64 ns |         - |