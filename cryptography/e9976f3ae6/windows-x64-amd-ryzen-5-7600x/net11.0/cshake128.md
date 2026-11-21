| Description                                      | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128B         |     246.7 ns |     0.72 ns |   0.60 ns |  16,511 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128B         |     319.7 ns |     0.29 ns |   0.24 ns |   9,477 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128B         |     340.5 ns |     0.34 ns |   0.32 ns |   8,500 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128B         |     395.5 ns |     0.58 ns |   0.49 ns |  15,840 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 137B         |     247.2 ns |     0.96 ns |   0.80 ns |  16,502 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 137B         |     317.2 ns |     0.38 ns |   0.36 ns |  15,812 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 137B         |     335.6 ns |     0.29 ns |   0.27 ns |   8,491 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 137B         |     397.1 ns |     1.19 ns |   1.06 ns |  15,650 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1KB          |   1,641.6 ns |     7.92 ns |   7.02 ns |  16,507 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1KB          |   2,108.9 ns |     1.51 ns |   1.41 ns |  15,998 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1KB          |   2,198.6 ns |     2.01 ns |   1.88 ns |   8,487 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1KB          |   2,477.4 ns |     5.35 ns |   4.74 ns |  17,054 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1025B        |   1,636.4 ns |     3.73 ns |   3.11 ns |  16,317 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1025B        |   2,124.0 ns |     1.29 ns |   1.14 ns |  15,998 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1025B        |   2,204.8 ns |     2.20 ns |   2.05 ns |  14,822 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1025B        |   2,472.0 ns |    10.67 ns |   8.91 ns |  10,529 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 8KB          |  11,353.1 ns |    23.72 ns |  21.03 ns |   9,973 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 8KB          |  14,656.0 ns |    11.85 ns |  11.08 ns |  16,009 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 8KB          |  15,211.7 ns |    10.60 ns |   9.40 ns |  14,822 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 8KB          |  17,211.1 ns |    43.93 ns |  36.68 ns |  16,856 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128KB        | 180,361.4 ns |   362.76 ns | 283.22 ns |  16,527 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128KB        | 233,934.7 ns |   121.84 ns | 113.97 ns |  15,998 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128KB        | 249,613.8 ns |   147.24 ns | 137.73 ns |  14,831 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128KB        | 274,222.3 ns | 1,064.22 ns | 995.47 ns |  10,520 B |         - |