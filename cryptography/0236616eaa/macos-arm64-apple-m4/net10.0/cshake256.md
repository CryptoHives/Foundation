| Description                                     | TestDataSize | Mean         | Error       | StdDev       | Median       | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|-------------:|-------------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128B         |     761.3 ns |     2.09 ns |      1.63 ns |     761.1 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     816.0 ns |    10.17 ns |      8.49 ns |     812.6 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     816.8 ns |     5.18 ns |      4.85 ns |     814.3 ns |         - |
|                                                 |              |              |             |              |              |           |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |     317.9 ns |     2.34 ns |      2.08 ns |     317.6 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     322.1 ns |     1.21 ns |      2.25 ns |     321.1 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 137B         |   1,448.8 ns |     1.77 ns |      1.38 ns |   1,448.8 ns |         - |
|                                                 |              |              |             |              |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1KB          |   1,199.5 ns |     1.66 ns |      1.47 ns |   1,199.2 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   1,229.1 ns |     5.22 ns |      4.36 ns |   1,230.2 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   1,312.9 ns |    11.43 ns |     10.69 ns |   1,316.5 ns |         - |
|                                                 |              |              |             |              |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1025B        |   1,213.4 ns |     2.11 ns |      1.87 ns |   1,213.3 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   1,239.2 ns |    16.22 ns |     15.17 ns |   1,237.5 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   1,295.2 ns |     4.77 ns |      4.46 ns |   1,293.1 ns |         - |
|                                                 |              |              |             |              |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 8KB          |   9,113.4 ns |    10.80 ns |     10.10 ns |   9,112.9 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |   9,200.4 ns |    34.57 ns |     30.64 ns |   9,181.5 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |   9,756.4 ns |    23.32 ns |     20.67 ns |   9,754.3 ns |         - |
|                                                 |              |              |             |              |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 165,905.5 ns | 3,777.18 ns | 11,077.83 ns | 162,875.5 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 166,287.9 ns | 3,287.76 ns |  5,493.11 ns | 163,392.2 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 179,352.5 ns | 3,586.41 ns |  7,079.21 ns | 179,983.9 ns |         - |