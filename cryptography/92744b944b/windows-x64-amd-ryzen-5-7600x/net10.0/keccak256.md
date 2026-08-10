| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128B         |     210.5 ns |   0.37 ns |   0.34 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128B         |     279.9 ns |   0.45 ns |   0.38 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128B         |     287.7 ns |   0.57 ns |   0.51 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128B         |     330.6 ns |   1.69 ns |   1.58 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 137B         |     461.8 ns |   0.64 ns |   0.57 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 137B         |     606.4 ns |   1.70 ns |   1.51 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 137B         |     624.8 ns |   1.36 ns |   1.20 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 137B         |     628.6 ns |   1.84 ns |   1.72 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1KB          |   1,615.1 ns |   3.87 ns |   3.62 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1KB          |   2,178.5 ns |   3.96 ns |   3.09 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1KB          |   2,241.6 ns |   5.12 ns |   4.54 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1KB          |   2,465.2 ns |   9.69 ns |   9.07 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1025B        |   1,614.3 ns |   3.80 ns |   3.37 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1025B        |   2,180.6 ns |   4.52 ns |   3.77 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1025B        |   2,236.2 ns |   3.58 ns |   3.17 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1025B        |   2,458.1 ns |   6.99 ns |   6.54 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 8KB          |  12,076.8 ns |  41.72 ns |  36.98 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 8KB          |  16,650.7 ns |  34.09 ns |  30.22 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 8KB          |  16,793.1 ns |  27.16 ns |  24.08 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 8KB          |  18,572.8 ns |  41.08 ns |  36.42 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128KB        | 193,050.3 ns | 684.65 ns | 640.42 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128KB        | 257,863.1 ns | 412.70 ns | 365.84 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128KB        | 264,299.7 ns | 562.84 ns | 439.43 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128KB        | 294,293.3 ns | 564.70 ns | 528.22 ns |         - |