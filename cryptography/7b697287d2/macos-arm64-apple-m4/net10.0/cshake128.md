| Description                                     | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128B         |     163.6 ns |     0.65 ns |   0.60 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     173.4 ns |     0.30 ns |   0.25 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     175.6 ns |     0.91 ns |   0.76 ns |         - |
|                                                 |              |              |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 137B         |     162.8 ns |     0.58 ns |   0.55 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     171.8 ns |     0.55 ns |   0.51 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     175.7 ns |     1.69 ns |   1.58 ns |         - |
|                                                 |              |              |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   1,055.7 ns |     3.40 ns |   3.18 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   1,096.5 ns |     8.60 ns |   7.62 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   1,143.0 ns |     4.76 ns |   4.45 ns |         - |
|                                                 |              |              |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1025B        |   1,063.5 ns |     2.30 ns |   2.15 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   1,102.8 ns |    14.71 ns |  13.76 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   1,145.7 ns |     4.09 ns |   3.82 ns |         - |
|                                                 |              |              |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   7,323.4 ns |    20.50 ns |  19.17 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |   7,552.1 ns |    68.58 ns |  64.15 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |   7,918.5 ns |    29.00 ns |  27.13 ns |         - |
|                                                 |              |              |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 117,893.7 ns |   262.08 ns | 245.15 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 119,800.7 ns | 1,003.12 ns | 938.32 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 126,033.0 ns |   579.69 ns | 542.25 ns |         - |