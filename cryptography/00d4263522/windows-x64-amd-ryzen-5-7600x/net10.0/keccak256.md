| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128B         |     217.5 ns |     0.74 ns |     0.69 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128B         |     282.1 ns |     1.20 ns |     1.12 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128B         |     291.1 ns |     0.69 ns |     0.57 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128B         |     340.3 ns |     1.46 ns |     1.30 ns |   7,932 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 137B         |     427.4 ns |     1.25 ns |     1.11 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 137B         |     557.2 ns |     2.30 ns |     2.15 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 137B         |     573.7 ns |     2.01 ns |     1.88 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 137B         |     643.1 ns |     1.10 ns |     0.86 ns |   9,187 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1KB          |   1,656.4 ns |     1.88 ns |     1.57 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1KB          |   2,186.2 ns |     9.25 ns |     7.73 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1KB          |   2,236.8 ns |    11.11 ns |    10.40 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1KB          |   2,564.1 ns |     6.09 ns |     5.09 ns |   9,268 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1025B        |   1,659.6 ns |     4.99 ns |     4.67 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1025B        |   2,213.3 ns |    11.37 ns |    10.08 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1025B        |   2,243.3 ns |     9.50 ns |     8.88 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1025B        |   2,558.2 ns |     7.47 ns |     6.24 ns |   9,268 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 8KB          |  12,539.8 ns |    36.61 ns |    32.45 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 8KB          |  16,599.7 ns |    67.90 ns |    63.51 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 8KB          |  16,991.8 ns |    95.52 ns |    84.68 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 8KB          |  19,082.3 ns |    16.58 ns |    13.85 ns |   9,214 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128KB        | 198,362.7 ns |   259.54 ns |   216.73 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128KB        | 261,829.2 ns | 1,133.41 ns | 1,060.19 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128KB        | 267,752.5 ns | 1,247.52 ns | 1,041.73 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128KB        | 304,995.4 ns |   438.56 ns |   366.21 ns |   9,250 B |         - |