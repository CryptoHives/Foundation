| Description                                          | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128B         |     124.0 ns |   1.79 ns |   2.45 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128B         |     155.3 ns |   0.58 ns |   0.52 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128B         |     163.7 ns |   0.63 ns |   0.52 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 137B         |     233.1 ns |   0.65 ns |   0.61 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 137B         |     295.9 ns |   1.59 ns |   1.41 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 137B         |     309.4 ns |   1.02 ns |   0.95 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1KB          |     895.2 ns |   3.03 ns |   2.83 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1KB          |   1,142.1 ns |  16.08 ns |  14.26 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1KB          |   1,180.9 ns |   6.05 ns |   5.05 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1025B        |     891.7 ns |   4.04 ns |   3.78 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1025B        |   1,136.9 ns |   3.12 ns |   2.92 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1025B        |   1,179.5 ns |   3.42 ns |   3.20 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 8KB          |   6,718.5 ns |  35.54 ns |  31.51 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 8KB          |   8,600.2 ns |  76.63 ns |  67.93 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 8KB          |   8,871.1 ns |  46.06 ns |  43.08 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128KB        | 105,941.5 ns | 665.03 ns | 519.21 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128KB        | 135,569.1 ns | 769.90 ns | 642.90 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128KB        | 139,998.9 ns | 535.38 ns | 474.60 ns |         - |