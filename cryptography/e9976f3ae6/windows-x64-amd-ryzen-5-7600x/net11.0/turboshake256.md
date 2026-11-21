| Description                                          | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128B         |     151.2 ns |   1.18 ns |   0.99 ns |  16,240 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128B         |     173.5 ns |   0.22 ns |   0.20 ns |   9,446 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128B         |     193.2 ns |   0.35 ns |   0.33 ns |   8,469 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 137B         |     262.6 ns |   0.57 ns |   0.45 ns |  16,279 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 137B         |     327.4 ns |   0.53 ns |   0.50 ns |  15,770 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 137B         |     344.8 ns |   0.38 ns |   0.36 ns |   8,408 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1KB          |   1,004.1 ns |   3.44 ns |   3.05 ns |  16,467 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1KB          |   1,265.2 ns |   0.69 ns |   0.57 ns |   9,442 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1KB          |   1,332.3 ns |   0.87 ns |   0.77 ns |   8,456 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1025B        |     995.3 ns |   2.22 ns |   1.96 ns |  16,277 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1025B        |   1,262.5 ns |   1.43 ns |   1.34 ns |  15,777 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1025B        |   1,313.5 ns |   1.64 ns |   1.54 ns |   8,465 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 8KB          |   7,480.8 ns |  13.76 ns |  12.20 ns |   9,942 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 8KB          |   9,474.3 ns |  12.15 ns |  10.15 ns |  15,967 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 8KB          |   9,901.8 ns |  14.42 ns |  13.49 ns |  14,800 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128KB        | 117,912.0 ns | 110.38 ns |  97.85 ns |  16,662 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128KB        | 149,257.3 ns | 150.61 ns | 133.51 ns |   9,433 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128KB        | 155,994.0 ns | 328.09 ns | 290.84 ns |   8,465 B |         - |