| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     439.7 ns |     0.87 ns |     0.77 ns |   5,663 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 128B         |     552.2 ns |     3.10 ns |     2.90 ns |   5,438 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     614.1 ns |     3.00 ns |     2.66 ns |   7,710 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     438.7 ns |     1.23 ns |     1.09 ns |   5,663 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 137B         |     552.4 ns |     3.14 ns |     2.94 ns |   5,436 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     614.0 ns |     2.41 ns |     2.25 ns |   7,712 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   2,933.6 ns |    11.93 ns |    11.16 ns |   5,626 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 1KB          |   3,769.5 ns |     7.43 ns |     6.95 ns |   5,399 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   3,973.7 ns |     8.15 ns |     7.62 ns |   8,323 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   2,938.2 ns |    11.75 ns |    10.99 ns |   5,628 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 1025B        |   3,685.9 ns |    16.53 ns |    15.46 ns |   5,401 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   3,966.4 ns |     5.36 ns |     4.47 ns |   8,294 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |  19,942.8 ns |    41.60 ns |    34.74 ns |   5,630 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 8KB          |  25,859.2 ns |    74.95 ns |    70.11 ns |   5,403 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |  27,688.1 ns |    26.74 ns |    23.71 ns |   8,320 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 316,847.3 ns | 1,545.99 ns | 1,446.12 ns |   5,626 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 128KB        | 427,219.2 ns | 1,901.03 ns | 1,778.23 ns |   5,399 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 439,198.4 ns |   378.40 ns |   353.95 ns |   8,293 B |         - |