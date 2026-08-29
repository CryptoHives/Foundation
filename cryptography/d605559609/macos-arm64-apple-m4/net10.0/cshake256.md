| Description                                     | TestDataSize | Mean         | Error        | StdDev        | Median       | Allocated |
|------------------------------------------------ |------------- |-------------:|-------------:|--------------:|-------------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128B         |     158.0 ns |      0.22 ns |       0.20 ns |     157.9 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     198.8 ns |      3.95 ns |       8.75 ns |     198.9 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     205.4 ns |      2.76 ns |       2.31 ns |     205.5 ns |         - |
|                                                 |              |              |              |               |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 137B         |     318.4 ns |     13.18 ns |      33.32 ns |     306.4 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |     319.0 ns |      5.78 ns |       5.41 ns |     317.4 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     337.0 ns |      3.92 ns |       3.27 ns |     336.1 ns |         - |
|                                                 |              |              |              |               |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1KB          |   1,198.5 ns |      1.68 ns |       1.49 ns |   1,198.3 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   1,231.1 ns |      4.43 ns |       3.93 ns |   1,229.9 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   1,294.6 ns |      3.68 ns |       3.44 ns |   1,293.5 ns |         - |
|                                                 |              |              |              |               |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1025B        |   1,200.1 ns |      1.86 ns |       1.65 ns |   1,199.4 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   1,230.6 ns |     11.66 ns |      10.91 ns |   1,226.2 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   1,295.9 ns |      1.94 ns |       1.62 ns |   1,295.4 ns |         - |
|                                                 |              |              |              |               |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 8KB          |  10,112.5 ns |    119.35 ns |      99.66 ns |  10,149.1 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |  10,183.1 ns |    124.90 ns |     110.72 ns |  10,181.4 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |  10,733.6 ns |    209.39 ns |     355.56 ns |  10,812.5 ns |         - |
|                                                 |              |              |              |               |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 185,223.8 ns |  3,660.66 ns |   5,590.21 ns | 187,310.6 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 188,546.3 ns |  3,666.46 ns |   4,894.62 ns | 189,096.4 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 406,016.7 ns | 87,981.87 ns | 259,416.55 ns | 180,041.9 ns |         - |