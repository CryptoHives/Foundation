| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128B         |     409.9 ns |     2.48 ns |     2.32 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128B         |     553.4 ns |     7.41 ns |     6.94 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128B         |     573.6 ns |     5.10 ns |     4.77 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128B         |     638.7 ns |     3.77 ns |     3.15 ns |   8,802 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 137B         |     410.4 ns |     2.93 ns |     2.44 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 137B         |     551.4 ns |     6.27 ns |     5.87 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 137B         |     565.8 ns |     7.42 ns |     6.58 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 137B         |     646.2 ns |     6.20 ns |     5.80 ns |   8,803 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1KB          |   3,009.9 ns |    30.07 ns |    28.13 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1KB          |   4,057.7 ns |    42.39 ns |    39.65 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1KB          |   4,175.4 ns |    40.94 ns |    38.30 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1KB          |   4,631.3 ns |    31.14 ns |    29.13 ns |   8,796 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1025B        |   3,015.8 ns |    19.95 ns |    18.66 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1025B        |   4,053.5 ns |    48.55 ns |    45.42 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1025B        |   4,166.1 ns |    46.60 ns |    38.91 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1025B        |   4,631.1 ns |    20.57 ns |    17.17 ns |   8,795 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 8KB          |  22,857.5 ns |   147.76 ns |   130.98 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 8KB          |  30,690.2 ns |   228.06 ns |   190.44 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 8KB          |  31,582.4 ns |   371.18 ns |   347.20 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 8KB          |  35,286.3 ns |   210.07 ns |   175.41 ns |   8,808 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128KB        | 363,127.5 ns | 1,594.41 ns | 1,491.41 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128KB        | 490,768.0 ns | 6,119.67 ns | 5,724.34 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128KB        | 506,129.2 ns | 5,200.27 ns | 4,864.33 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128KB        | 563,698.4 ns | 3,782.38 ns | 3,538.04 ns |   8,809 B |         - |