| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128B         |     248.6 ns |   0.79 ns |   0.74 ns |   5,624 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128B         |     325.6 ns |   0.20 ns |   0.18 ns |   5,149 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128B         |     328.7 ns |   0.34 ns |   0.32 ns |   4,128 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128B         |     381.7 ns |   0.40 ns |   0.37 ns |   7,656 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 137B         |     245.4 ns |   0.46 ns |   0.43 ns |   5,640 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 137B         |     317.0 ns |   0.24 ns |   0.23 ns |   5,133 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 137B         |     337.5 ns |   0.24 ns |   0.21 ns |   4,128 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 137B         |     383.9 ns |   0.59 ns |   0.55 ns |   7,665 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1KB          |   1,625.0 ns |   2.39 ns |   2.24 ns |   5,606 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1KB          |   2,134.1 ns |   1.18 ns |   1.10 ns |   5,115 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1KB          |   2,178.9 ns |   1.74 ns |   1.63 ns |   4,110 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1KB          |   2,505.6 ns |   5.17 ns |   4.83 ns |   8,256 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1025B        |   1,628.3 ns |   2.21 ns |   2.07 ns |   5,608 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1025B        |   2,129.5 ns |   1.10 ns |   1.03 ns |   5,117 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1025B        |   2,180.5 ns |   2.17 ns |   2.03 ns |   4,112 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1025B        |   2,499.9 ns |   4.23 ns |   3.95 ns |   8,260 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 8KB          |  11,283.4 ns |  15.68 ns |  14.67 ns |   5,612 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 8KB          |  14,800.1 ns |   5.29 ns |   4.95 ns |   5,119 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 8KB          |  15,134.0 ns |  12.18 ns |  11.39 ns |   4,116 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 8KB          |  17,552.3 ns |  35.69 ns |  31.64 ns |   8,249 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128KB        | 179,485.2 ns | 315.73 ns | 295.34 ns |   5,606 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128KB        | 235,604.7 ns |  60.47 ns |  56.57 ns |   5,115 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128KB        | 241,063.6 ns | 184.45 ns | 172.53 ns |   4,110 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128KB        | 277,246.1 ns | 509.41 ns | 425.38 ns |   8,261 B |         - |