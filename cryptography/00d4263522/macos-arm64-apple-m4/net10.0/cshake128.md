| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128B         |     163.9 ns |     3.14 ns |     2.94 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     172.8 ns |     2.52 ns |     2.36 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     173.9 ns |     2.53 ns |     2.24 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 137B         |     160.3 ns |     0.14 ns |     0.11 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     172.5 ns |     2.44 ns |     2.28 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     175.6 ns |     2.73 ns |     2.56 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   1,057.5 ns |     2.68 ns |     2.10 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   1,084.1 ns |     6.38 ns |     4.98 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   1,144.0 ns |     3.75 ns |     2.93 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1025B        |   1,054.4 ns |     0.94 ns |     0.73 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   1,090.2 ns |     3.12 ns |     2.43 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   1,158.0 ns |    20.85 ns |    19.50 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   7,361.2 ns |     6.59 ns |     5.50 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |   7,558.0 ns |    93.93 ns |    87.86 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |   7,842.7 ns |    14.30 ns |    11.17 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 117,934.5 ns | 1,577.12 ns | 1,475.24 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 120,545.0 ns | 1,439.47 ns | 1,346.48 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 125,099.7 ns |   354.01 ns |   276.39 ns |         - |