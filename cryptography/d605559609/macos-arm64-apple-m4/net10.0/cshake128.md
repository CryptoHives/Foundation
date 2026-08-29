| Description                                     | TestDataSize | Mean         | Error       | StdDev       | Median       | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|-------------:|-------------:|----------:|
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     170.6 ns |     2.96 ns |      3.63 ns |     168.7 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128B         |     756.1 ns |     1.28 ns |      1.13 ns |     755.8 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     814.1 ns |     2.63 ns |      2.46 ns |     814.2 ns |         - |
|                                                 |              |              |             |              |              |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 137B         |     161.1 ns |     1.98 ns |      1.75 ns |     160.1 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     171.2 ns |     0.45 ns |      0.42 ns |     171.0 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     174.0 ns |     1.26 ns |      1.11 ns |     173.8 ns |         - |
|                                                 |              |              |             |              |              |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   1,049.4 ns |     0.83 ns |      0.74 ns |   1,049.3 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   1,090.4 ns |    10.53 ns |      9.33 ns |   1,086.4 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   1,136.8 ns |     1.24 ns |      0.97 ns |   1,136.8 ns |         - |
|                                                 |              |              |             |              |              |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1025B        |   1,156.1 ns |    22.91 ns |     24.51 ns |   1,160.3 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   1,190.6 ns |    23.75 ns |     39.69 ns |   1,191.8 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   1,243.8 ns |    11.48 ns |     10.74 ns |   1,247.0 ns |         - |
|                                                 |              |              |             |              |              |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   9,140.6 ns |   182.57 ns |    261.83 ns |   9,078.6 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |   9,495.4 ns |   186.17 ns |    358.69 ns |   9,451.1 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |  20,248.5 ns | 4,541.03 ns | 13,318.05 ns |   9,201.3 ns |         - |
|                                                 |              |              |             |              |              |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 116,566.3 ns |   127.58 ns |     99.61 ns | 116,539.0 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 118,903.8 ns |   764.68 ns |    715.28 ns | 118,561.0 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 125,214.9 ns |   283.34 ns |    221.21 ns | 125,173.4 ns |         - |