| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128B         |     161.5 ns |     0.57 ns |     0.54 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     172.8 ns |     0.66 ns |     0.62 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     176.3 ns |     0.86 ns |     0.76 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 137B         |     310.6 ns |     0.56 ns |     0.52 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |     323.5 ns |     2.41 ns |     2.01 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     333.3 ns |     1.07 ns |     1.00 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1KB          |   1,211.0 ns |     4.30 ns |     4.02 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   1,250.0 ns |    11.88 ns |    11.11 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   1,297.7 ns |     4.61 ns |     4.31 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1025B        |   1,210.4 ns |     3.92 ns |     3.67 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   1,247.9 ns |    10.61 ns |     9.41 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   1,299.8 ns |     4.07 ns |     3.81 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 8KB          |   9,155.8 ns |    44.55 ns |    41.67 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |   9,238.9 ns |    33.03 ns |    27.58 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |   9,809.3 ns |    25.71 ns |    24.05 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 146,764.5 ns | 1,182.31 ns | 1,048.09 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 146,872.0 ns |   605.88 ns |   566.74 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 155,203.8 ns |   488.66 ns |   457.09 ns |         - |