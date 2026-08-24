| Description                                          | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128B         |     122.6 ns |   0.18 ns |   0.15 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128B         |     154.6 ns |   0.65 ns |   0.58 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128B         |     163.8 ns |   0.50 ns |   0.39 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 137B         |     232.1 ns |   0.99 ns |   0.83 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 137B         |     295.6 ns |   1.34 ns |   1.12 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 137B         |     309.0 ns |   1.47 ns |   1.15 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1KB          |     886.6 ns |   2.64 ns |   2.34 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1KB          |   1,133.7 ns |   3.80 ns |   3.55 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1KB          |   1,174.5 ns |   4.59 ns |   4.07 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1025B        |     885.9 ns |   0.79 ns |   0.66 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1025B        |   1,134.9 ns |   2.98 ns |   2.32 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1025B        |   1,175.5 ns |   5.13 ns |   4.80 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 8KB          |   6,673.6 ns |  15.22 ns |  12.71 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 8KB          |   8,566.2 ns |  22.85 ns |  21.38 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 8KB          |   8,911.5 ns |  63.36 ns |  52.91 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128KB        | 105,026.4 ns |  91.60 ns |  76.49 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128KB        | 135,061.9 ns | 606.95 ns | 567.74 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128KB        | 139,686.0 ns | 559.51 ns | 523.37 ns |         - |