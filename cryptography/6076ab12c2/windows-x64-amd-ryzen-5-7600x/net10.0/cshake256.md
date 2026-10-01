| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128B         |     242.8 ns |   0.76 ns |   0.67 ns |   5,619 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128B         |     323.0 ns |   0.20 ns |   0.18 ns |   5,128 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128B         |     328.0 ns |   0.24 ns |   0.23 ns |   4,123 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128B         |     380.1 ns |   0.52 ns |   0.46 ns |   7,653 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 137B         |     471.6 ns |   0.73 ns |   0.65 ns |   5,603 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 137B         |     616.2 ns |   0.26 ns |   0.23 ns |   5,112 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 137B         |     635.4 ns |   0.61 ns |   0.57 ns |   4,103 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 137B         |     727.3 ns |   0.60 ns |   0.53 ns |   8,931 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1KB          |   1,839.9 ns |   2.45 ns |   2.29 ns |   5,607 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1KB          |   2,423.4 ns |   1.48 ns |   1.38 ns |   5,116 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1KB          |   2,478.4 ns |   2.29 ns |   2.14 ns |   4,111 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1KB          |   2,846.8 ns |   3.26 ns |   2.72 ns |   8,910 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1025B        |   1,839.7 ns |   2.37 ns |   2.10 ns |   5,607 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1025B        |   2,420.7 ns |   1.45 ns |   1.35 ns |   5,116 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1025B        |   2,493.9 ns |   2.32 ns |   2.17 ns |   4,111 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1025B        |   2,852.7 ns |   4.58 ns |   4.29 ns |   8,914 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 8KB          |  13,938.7 ns |  26.85 ns |  22.42 ns |   5,604 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 8KB          |  18,326.4 ns |  14.11 ns |  13.20 ns |   5,115 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 8KB          |  18,763.2 ns |  15.89 ns |  14.86 ns |   4,108 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 8KB          |  21,343.0 ns |  63.23 ns |  59.14 ns |   8,904 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128KB        | 219,889.7 ns | 377.53 ns | 353.14 ns |   5,605 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128KB        | 288,989.1 ns | 180.64 ns | 168.97 ns |   5,114 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128KB        | 295,889.2 ns | 202.72 ns | 179.71 ns |   4,109 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128KB        | 338,904.8 ns | 515.47 ns | 456.95 ns |   8,900 B |         - |