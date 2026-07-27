| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128B         |     121.6 ns |     0.51 ns |     0.40 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128B         |     155.8 ns |     1.58 ns |     1.23 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128B         |     164.9 ns |     1.36 ns |     1.20 ns |         - |
|                                                      |              |              |             |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 137B         |     230.7 ns |     0.88 ns |     0.73 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 137B         |     298.2 ns |     3.27 ns |     3.05 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 137B         |     312.8 ns |     3.45 ns |     2.88 ns |         - |
|                                                      |              |              |             |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1KB          |     898.6 ns |     9.89 ns |     8.26 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1KB          |   1,178.0 ns |    23.14 ns |    33.92 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1KB          |   1,218.3 ns |    23.13 ns |    28.40 ns |         - |
|                                                      |              |              |             |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1025B        |     904.1 ns |     8.90 ns |     7.43 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1025B        |   1,204.2 ns |    18.02 ns |    15.98 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1025B        |   1,207.4 ns |    23.87 ns |    48.77 ns |         - |
|                                                      |              |              |             |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 8KB          |   6,808.2 ns |   103.03 ns |    91.33 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 8KB          |   8,795.9 ns |   151.04 ns |   133.90 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 8KB          |   9,270.9 ns |   183.55 ns |   274.73 ns |         - |
|                                                      |              |              |             |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128KB        | 107,926.4 ns | 1,740.65 ns | 1,628.20 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128KB        | 138,723.3 ns | 2,337.09 ns | 2,186.11 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128KB        | 142,596.0 ns | 2,838.85 ns | 2,655.46 ns |         - |