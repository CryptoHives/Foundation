| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128B         |     244.0 ns |   0.59 ns |   0.52 ns |   5,624 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128B         |     318.3 ns |   0.23 ns |   0.22 ns |   5,115 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128B         |     329.7 ns |   0.20 ns |   0.19 ns |   4,128 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128B         |     379.9 ns |   0.87 ns |   0.81 ns |   7,656 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 137B         |     244.7 ns |   0.85 ns |   0.79 ns |   5,624 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 137B         |     316.0 ns |   0.22 ns |   0.20 ns |   5,131 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 137B         |     328.9 ns |   0.27 ns |   0.25 ns |   4,128 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 137B         |     380.6 ns |   0.65 ns |   0.61 ns |   7,665 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1KB          |   1,625.5 ns |   2.11 ns |   1.97 ns |   5,606 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1KB          |   2,131.2 ns |   0.70 ns |   0.62 ns |   5,097 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1KB          |   2,180.4 ns |   1.99 ns |   1.77 ns |   4,110 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1KB          |   2,506.8 ns |   1.75 ns |   1.55 ns |   8,248 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1025B        |   1,624.4 ns |   2.26 ns |   2.12 ns |   5,610 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1025B        |   2,129.0 ns |   1.35 ns |   1.26 ns |   5,099 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1025B        |   2,177.7 ns |   1.49 ns |   1.40 ns |   4,112 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1025B        |   2,519.3 ns |   4.85 ns |   4.53 ns |   8,258 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 8KB          |  11,288.7 ns |  20.27 ns |  18.97 ns |   5,612 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 8KB          |  14,850.8 ns |   4.52 ns |   4.23 ns |   5,101 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 8KB          |  15,111.7 ns |  15.62 ns |  14.61 ns |   4,116 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 8KB          |  17,581.6 ns |  37.42 ns |  35.01 ns |   8,253 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128KB        | 179,711.1 ns | 325.17 ns | 304.17 ns |   5,606 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128KB        | 235,875.1 ns |  83.93 ns |  78.51 ns |   5,097 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128KB        | 240,328.0 ns | 124.76 ns | 116.70 ns |   4,110 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128KB        | 276,920.6 ns | 356.10 ns | 333.10 ns |   8,237 B |         - |