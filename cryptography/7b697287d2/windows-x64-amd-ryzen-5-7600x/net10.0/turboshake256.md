| Description                                          | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128B         |     138.3 ns |   0.34 ns |   0.32 ns |   5,589 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128B         |     170.9 ns |   0.14 ns |   0.12 ns |   5,080 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128B         |     180.3 ns |   0.15 ns |   0.14 ns |   4,091 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 137B         |     259.5 ns |   0.98 ns |   0.87 ns |   5,565 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 137B         |     326.8 ns |   0.26 ns |   0.24 ns |   5,060 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 137B         |     340.8 ns |   0.28 ns |   0.25 ns |   4,069 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1KB          |     992.0 ns |   1.40 ns |   1.24 ns |   5,573 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1KB          |   1,255.5 ns |   1.25 ns |   1.11 ns |   5,064 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1KB          |   1,305.8 ns |   0.79 ns |   0.70 ns |   4,077 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1025B        |     994.0 ns |   2.27 ns |   2.12 ns |   5,573 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1025B        |   1,259.6 ns |   1.02 ns |   0.86 ns |   5,064 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1025B        |   1,306.2 ns |   0.87 ns |   0.82 ns |   4,077 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 8KB          |   7,454.1 ns |   5.36 ns |   4.75 ns |   5,572 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 8KB          |   9,627.6 ns |   5.59 ns |   4.95 ns |   5,063 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 8KB          |   9,810.7 ns |   7.90 ns |   7.39 ns |   4,076 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128KB        | 117,478.7 ns | 201.63 ns | 188.60 ns |   5,571 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128KB        | 149,325.2 ns |  95.04 ns |  79.36 ns |   5,062 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128KB        | 154,655.7 ns | 104.23 ns |  92.39 ns |   4,075 B |         - |