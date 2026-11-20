| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     438.8 ns |   0.90 ns |   0.80 ns |  16,352 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 128B         |     545.6 ns |   2.25 ns |   2.11 ns |   9,777 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     606.3 ns |   1.16 ns |   0.97 ns |   9,351 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     440.3 ns |   0.40 ns |   0.35 ns |  10,008 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 137B         |     546.1 ns |   1.63 ns |   1.53 ns |   9,777 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     609.8 ns |   3.46 ns |   3.24 ns |   9,351 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   2,939.2 ns |  11.78 ns |  10.44 ns |  16,339 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 1KB          |   3,715.8 ns |  10.54 ns |   9.86 ns |  16,099 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   3,916.3 ns |   2.14 ns |   1.90 ns |  16,905 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   2,919.5 ns |   1.28 ns |   1.20 ns |  16,339 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 1025B        |   3,670.8 ns |   8.32 ns |   7.78 ns |  16,099 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   3,922.6 ns |   8.52 ns |   7.56 ns |  17,095 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |  19,931.7 ns |  21.37 ns |  18.94 ns |  16,348 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 8KB          |  25,282.4 ns |  61.12 ns |  57.17 ns |  16,099 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |  27,148.0 ns |  21.49 ns |  20.10 ns |  16,897 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 316,770.5 ns | 698.49 ns | 619.19 ns |  16,348 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 128KB        | 404,475.3 ns | 571.54 ns | 534.62 ns |  16,099 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 431,702.3 ns | 498.84 ns | 466.61 ns |  16,896 B |         - |