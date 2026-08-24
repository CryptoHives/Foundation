| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128B         |     410.4 ns |     0.38 ns |     0.34 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128B         |     572.7 ns |     1.76 ns |     1.56 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128B         |     631.2 ns |     2.24 ns |     2.09 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128B         |     636.3 ns |     0.96 ns |     0.80 ns |   9,201 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 137B         |     411.1 ns |     1.24 ns |     1.10 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 137B         |     546.8 ns |     2.06 ns |     1.72 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 137B         |     562.8 ns |     1.42 ns |     1.26 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 137B         |     636.0 ns |     1.26 ns |     1.05 ns |   9,216 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1KB          |   3,008.1 ns |     7.51 ns |     6.27 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1KB          |   4,014.7 ns |     7.27 ns |     6.80 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1KB          |   4,153.3 ns |    34.92 ns |    30.95 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1KB          |   4,696.2 ns |    10.33 ns |     9.16 ns |   9,240 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1025B        |   3,010.2 ns |     8.13 ns |     7.21 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1025B        |   4,028.9 ns |     6.81 ns |     6.04 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1025B        |   4,143.5 ns |    26.19 ns |    21.87 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1025B        |   4,664.0 ns |     4.99 ns |     4.67 ns |   9,210 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 8KB          |  22,842.2 ns |    42.73 ns |    35.68 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 8KB          |  30,543.7 ns |   200.77 ns |   167.65 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 8KB          |  31,535.4 ns |    66.07 ns |    55.17 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 8KB          |  35,208.1 ns |    57.62 ns |    48.12 ns |   9,230 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128KB        | 364,838.8 ns | 1,143.16 ns | 1,013.38 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128KB        | 488,736.5 ns | 2,467.73 ns | 2,308.31 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128KB        | 502,329.1 ns | 2,256.21 ns | 2,110.46 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128KB        | 565,257.1 ns | 1,330.63 ns | 1,111.14 ns |   9,235 B |         - |