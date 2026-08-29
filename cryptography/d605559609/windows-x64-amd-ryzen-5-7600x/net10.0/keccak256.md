| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128B         |     217.5 ns |     1.11 ns |     0.92 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128B         |     283.8 ns |     4.32 ns |     3.61 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128B         |     293.0 ns |     1.03 ns |     0.96 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128B         |     336.7 ns |     1.23 ns |     1.09 ns |   7,950 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 137B         |     423.5 ns |     2.39 ns |     1.86 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 137B         |     555.5 ns |     1.55 ns |     1.37 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 137B         |     574.8 ns |     2.38 ns |     1.86 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 137B         |     638.9 ns |     1.05 ns |     0.82 ns |   9,233 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1KB          |   1,652.7 ns |     5.91 ns |     5.24 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1KB          |   2,203.1 ns |    43.67 ns |    34.10 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1KB          |   2,237.5 ns |     7.25 ns |     6.78 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1KB          |   2,536.4 ns |     7.46 ns |     6.61 ns |   9,218 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1025B        |   1,655.7 ns |     7.94 ns |     7.04 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1025B        |   2,190.3 ns |    15.09 ns |    12.60 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1025B        |   2,238.1 ns |     8.87 ns |     7.86 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1025B        |   2,539.6 ns |    11.55 ns |    10.80 ns |   9,250 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 8KB          |  12,519.0 ns |    52.53 ns |    46.57 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 8KB          |  16,585.4 ns |    72.54 ns |    60.57 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 8KB          |  17,182.7 ns |   335.70 ns |   399.63 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 8KB          |  19,152.3 ns |   141.98 ns |   118.56 ns |   9,199 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128KB        | 198,257.0 ns | 1,525.65 ns | 1,352.45 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128KB        | 262,871.1 ns | 1,393.30 ns | 1,235.13 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128KB        | 267,460.3 ns | 1,056.95 ns |   936.96 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128KB        | 303,582.2 ns | 1,151.86 ns | 1,077.45 ns |   9,218 B |         - |