| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Median       | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128B         |     422.5 ns |     8.03 ns |     6.27 ns |     421.5 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128B         |     554.1 ns |     1.61 ns |     1.50 ns |     554.0 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128B         |     573.2 ns |     2.98 ns |     2.49 ns |     572.2 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128B         |     641.5 ns |     1.54 ns |     1.37 ns |     641.5 ns |   9,182 B |         - |
|                                                   |              |              |             |             |              |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 137B         |     417.8 ns |     1.72 ns |     1.60 ns |     417.7 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 137B         |     564.5 ns |    11.11 ns |    16.28 ns |     556.0 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 137B         |     574.9 ns |     2.00 ns |     1.87 ns |     575.0 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 137B         |     639.9 ns |     2.05 ns |     1.91 ns |     640.1 ns |   9,136 B |         - |
|                                                   |              |              |             |             |              |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1KB          |   2,043.2 ns |    11.70 ns |    10.37 ns |   2,039.3 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1KB          |   2,719.9 ns |     8.69 ns |     7.70 ns |   2,718.8 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1KB          |   2,784.9 ns |    10.31 ns |     9.65 ns |   2,783.0 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1KB          |   3,144.9 ns |    13.39 ns |    11.18 ns |   3,141.9 ns |   9,189 B |         - |
|                                                   |              |              |             |             |              |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1025B        |   2,040.3 ns |     5.96 ns |     5.28 ns |   2,040.3 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1025B        |   2,721.7 ns |     5.85 ns |     5.48 ns |   2,721.6 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1025B        |   2,785.7 ns |     7.74 ns |     7.24 ns |   2,785.8 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1025B        |   3,150.5 ns |     6.86 ns |     6.08 ns |   3,150.2 ns |   9,203 B |         - |
|                                                   |              |              |             |             |              |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 8KB          |  16,090.0 ns |    72.31 ns |    64.10 ns |  16,068.3 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 8KB          |  21,462.9 ns |    71.59 ns |    63.46 ns |  21,440.9 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 8KB          |  21,993.8 ns |    91.14 ns |    76.10 ns |  21,970.3 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 8KB          |  24,648.3 ns |    65.26 ns |    50.95 ns |  24,669.4 ns |   9,208 B |         - |
|                                                   |              |              |             |             |              |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128KB        | 257,077.0 ns |   603.70 ns |   504.12 ns | 257,098.2 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128KB        | 341,237.7 ns | 1,279.70 ns | 1,197.03 ns | 341,466.2 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128KB        | 351,924.6 ns | 3,156.43 ns | 2,635.76 ns | 350,754.1 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128KB        | 394,361.0 ns | 1,553.05 ns | 1,452.73 ns | 394,342.6 ns |   9,208 B |         - |