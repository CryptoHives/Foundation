| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128B         |     164.5 ns |     3.26 ns |     3.05 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128B         |     188.3 ns |     3.61 ns |     3.20 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128B         |     189.0 ns |     0.55 ns |     0.46 ns |         - |
|                                                      |              |              |             |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 137B         |     324.2 ns |     5.38 ns |     4.77 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 137B         |     380.7 ns |     6.25 ns |     6.69 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 137B         |     393.6 ns |     6.88 ns |     6.09 ns |         - |
|                                                      |              |              |             |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1KB          |     934.8 ns |     4.04 ns |     3.58 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1KB          |   1,197.9 ns |     7.65 ns |     6.78 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1KB          |   1,241.1 ns |     6.74 ns |     5.97 ns |         - |
|                                                      |              |              |             |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1025B        |     946.0 ns |    15.45 ns |    14.45 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1025B        |   1,199.4 ns |    10.63 ns |     9.42 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1025B        |   1,238.3 ns |     4.32 ns |     3.61 ns |         - |
|                                                      |              |              |             |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 8KB          |   6,609.3 ns |    61.99 ns |    51.77 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 8KB          |   8,584.7 ns |   118.81 ns |    99.21 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 8KB          |   8,981.9 ns |   145.58 ns |   129.05 ns |         - |
|                                                      |              |              |             |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128KB        | 103,795.5 ns | 1,827.37 ns | 1,709.33 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128KB        | 133,820.7 ns |   407.37 ns |   361.13 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128KB        | 139,277.3 ns | 1,547.14 ns | 1,371.50 ns |         - |