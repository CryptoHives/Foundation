| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     435.6 ns |     0.49 ns |     0.43 ns |  16,343 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 128B         |     579.0 ns |     1.21 ns |     1.13 ns |   9,777 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     606.9 ns |     0.94 ns |     0.78 ns |  15,868 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     838.5 ns |     1.14 ns |     0.89 ns |  16,332 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 137B         |   1,052.4 ns |     3.87 ns |     3.62 ns |   9,757 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |   1,134.5 ns |     1.36 ns |     1.21 ns |  17,152 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   3,325.3 ns |    10.35 ns |     9.68 ns |  16,339 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 1KB          |   4,141.8 ns |     7.42 ns |     6.94 ns |  16,298 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   4,450.7 ns |     2.46 ns |     2.30 ns |  10,590 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   3,306.8 ns |     2.71 ns |     2.26 ns |  16,348 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 1025B        |   4,179.4 ns |    18.94 ns |    17.72 ns |   9,764 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   4,457.2 ns |     1.44 ns |     1.28 ns |  10,590 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |  24,691.3 ns |    26.65 ns |    23.62 ns |  16,529 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 8KB          |  31,340.5 ns |   152.69 ns |   142.83 ns |   9,764 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |  33,772.5 ns |    39.69 ns |    37.13 ns |  10,582 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 388,401.5 ns |   819.42 ns |   726.39 ns |  16,339 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 128KB        | 499,632.4 ns | 1,539.01 ns | 1,364.29 ns |  16,099 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 530,017.6 ns |   601.16 ns |   532.92 ns |  16,927 B |         - |