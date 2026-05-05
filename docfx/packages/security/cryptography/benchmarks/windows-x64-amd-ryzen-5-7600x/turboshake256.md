| Description                                          | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128B         |     118.2 ns |   0.39 ns |   0.34 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128B         |     152.5 ns |   0.33 ns |   0.31 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128B         |     160.4 ns |   0.49 ns |   0.41 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 137B         |     224.6 ns |   1.05 ns |   0.98 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 137B         |     292.4 ns |   0.70 ns |   0.65 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 137B         |     310.8 ns |   0.77 ns |   0.65 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1KB          |     861.5 ns |   3.24 ns |   3.03 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1KB          |   1,126.8 ns |   1.84 ns |   1.53 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1KB          |   1,173.7 ns |   3.68 ns |   3.44 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1025B        |     860.2 ns |   2.05 ns |   1.82 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1025B        |   1,128.6 ns |   2.92 ns |   2.44 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1025B        |   1,176.5 ns |   3.41 ns |   3.02 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 8KB          |   6,501.0 ns |  31.46 ns |  29.43 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 8KB          |   8,505.7 ns |  24.96 ns |  23.34 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 8KB          |   8,812.6 ns |  16.56 ns |  14.68 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128KB        | 102,407.1 ns | 362.07 ns | 302.35 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128KB        | 134,221.3 ns | 386.34 ns | 342.48 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128KB        | 139,002.7 ns | 356.00 ns | 315.59 ns |         - |