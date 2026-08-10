| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128B         |     412.3 ns |     1.83 ns |     1.53 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128B         |     555.2 ns |     6.38 ns |     5.96 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128B         |     573.5 ns |     5.91 ns |     5.53 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128B         |     638.9 ns |     3.39 ns |     3.01 ns |   8,809 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 137B         |     413.2 ns |     2.47 ns |     2.31 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 137B         |     556.4 ns |     8.22 ns |     7.29 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 137B         |     573.3 ns |     4.74 ns |     4.20 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 137B         |     642.6 ns |     4.32 ns |     4.04 ns |   8,810 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1KB          |   2,019.4 ns |    20.60 ns |    18.26 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1KB          |   2,725.3 ns |    19.91 ns |    18.62 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1KB          |   2,796.5 ns |    25.00 ns |    22.16 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1KB          |   3,129.9 ns |    16.26 ns |    12.70 ns |   8,811 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1025B        |   2,027.6 ns |    24.78 ns |    21.97 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1025B        |   2,722.4 ns |    24.00 ns |    20.04 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1025B        |   2,794.7 ns |    27.07 ns |    25.32 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1025B        |   3,124.4 ns |    12.75 ns |    10.65 ns |   8,823 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 8KB          |  15,856.9 ns |   110.99 ns |   103.82 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 8KB          |  21,443.9 ns |   179.87 ns |   168.25 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 8KB          |  22,024.9 ns |   198.89 ns |   186.04 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 8KB          |  24,486.1 ns |   145.69 ns |   136.28 ns |   8,830 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128KB        | 253,014.0 ns | 1,536.04 ns | 1,282.66 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128KB        | 342,445.3 ns | 2,617.48 ns | 2,448.39 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128KB        | 351,929.0 ns | 3,853.09 ns | 3,415.66 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128KB        | 391,867.8 ns | 2,025.85 ns | 1,795.86 ns |   8,825 B |         - |