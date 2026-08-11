| Description                                          | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128B         |     126.5 ns |   0.67 ns |   0.63 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128B         |     155.5 ns |   0.67 ns |   0.56 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128B         |     164.2 ns |   0.99 ns |   0.88 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 137B         |     236.1 ns |   0.68 ns |   0.64 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 137B         |     296.9 ns |   0.88 ns |   0.78 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 137B         |     311.0 ns |   1.12 ns |   0.99 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1KB          |     898.3 ns |   1.38 ns |   1.08 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1KB          |   1,140.7 ns |   6.00 ns |   5.62 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1KB          |   1,182.3 ns |   6.48 ns |   5.74 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1025B        |     900.1 ns |   2.06 ns |   1.83 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1025B        |   1,162.6 ns |   4.76 ns |   3.98 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1025B        |   1,180.8 ns |   4.93 ns |   4.61 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 8KB          |   6,770.5 ns |  17.56 ns |  15.56 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 8KB          |   8,592.0 ns |  59.40 ns |  55.56 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 8KB          |   8,879.7 ns |  41.53 ns |  36.82 ns |         - |
|                                                      |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128KB        | 107,031.9 ns | 195.04 ns | 152.27 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128KB        | 135,554.8 ns | 783.66 ns | 654.39 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128KB        | 140,002.3 ns | 484.99 ns | 378.65 ns |         - |