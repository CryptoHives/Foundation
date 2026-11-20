| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128B         |     246.1 ns |   0.89 ns |   0.83 ns |   9,986 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128B         |     315.4 ns |   0.35 ns |   0.33 ns |  15,812 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128B         |     337.0 ns |   0.30 ns |   0.28 ns |  14,826 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128B         |     403.5 ns |   1.39 ns |   1.30 ns |  15,832 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 137B         |     476.0 ns |   1.07 ns |   0.95 ns |   9,966 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 137B         |     617.2 ns |   0.73 ns |   0.65 ns |   9,466 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 137B         |     658.1 ns |   0.39 ns |   0.37 ns |  14,824 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 137B         |     729.8 ns |   2.92 ns |   2.73 ns |  16,926 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1KB          |   1,851.1 ns |   3.24 ns |   2.53 ns |  16,507 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1KB          |   2,398.4 ns |   2.40 ns |   2.13 ns |  15,799 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1KB          |   2,503.7 ns |   1.46 ns |   1.30 ns |  15,021 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1KB          |   2,831.4 ns |   7.12 ns |   5.95 ns |  10,540 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1025B        |   1,854.1 ns |   6.94 ns |   6.15 ns |  16,507 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1025B        |   2,414.2 ns |   1.49 ns |   1.32 ns |  15,998 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1025B        |   2,507.9 ns |   1.94 ns |   1.81 ns |  15,021 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1025B        |   2,821.8 ns |   9.16 ns |   7.65 ns |  10,540 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 8KB          |  14,061.1 ns |  70.21 ns |  65.67 ns |  16,317 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 8KB          |  18,616.7 ns |  15.30 ns |  13.57 ns |  15,808 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 8KB          |  18,915.4 ns |  14.74 ns |  13.79 ns |  14,831 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 8KB          |  21,347.6 ns |  33.78 ns |  29.94 ns |  10,532 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128KB        | 221,197.7 ns | 918.94 ns | 717.45 ns |  16,317 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128KB        | 288,013.4 ns | 155.35 ns | 137.72 ns |   9,464 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128KB        | 298,246.5 ns | 240.63 ns | 225.09 ns |  15,236 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128KB        | 335,828.6 ns | 735.46 ns | 614.15 ns |  10,542 B |         - |